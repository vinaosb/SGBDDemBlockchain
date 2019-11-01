using API.Comunicacao;
using Nethereum.Contracts;
using Nethereum.Web3;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace API.Blockchain
{
	public class EventPool
	{
		public Event<DataModifiedEventDTO> eventDataModifiedLog;
		public List<EventLog<DataModifiedEventDTO>> ListEventDataModifiedLog { get; set; }
		public Event<DataDeletedEventDTO> eventDataDeletedLog;
		public List<EventLog<DataDeletedEventDTO>> ListEventDataDeletedLog { get; set; }

		public EventHandlerBlockchain Handler { get; set; }


		public EventPool(Web3 web3)
		{
			Handler = new EventHandlerBlockchain();
			eventDataModifiedLog = web3.Eth.GetEvent<DataModifiedEventDTO>("DataModified");
			eventDataDeletedLog = web3.Eth.GetEvent<DataDeletedEventDTO>("DataDeleted");

			_ = EventPooling();
		}

		public async Task EventPooling()
		{
			var filter = eventDataModifiedLog.CreateFilterInput();
			var filter2 = eventDataDeletedLog.CreateFilterInput();

			Dictionary<uint, HashSet<ulong>> dbAndTables = new Dictionary<uint, HashSet<ulong>>();
			Dictionary<ulong, HashSet<BigInteger>> tableAndData = new Dictionary<ulong, HashSet<BigInteger>>();
			Dictionary<BigInteger, (byte[], byte[])> dataAndHashs = new Dictionary<BigInteger, (byte[], byte[])>();

			while (true)
			{
				System.Threading.Thread.Sleep(5000);
				var log = await eventDataModifiedLog.GetAllChanges(filter);

				if (ListEventDataModifiedLog.Count != log.Count)
				{
					var dif = ListEventDataModifiedLog.Intersect(log);

					var loop = dif.Except(log);

					string sender = null;
					foreach (var item in loop)
					{
						dbAndTables.TryAdd(item.Event.DbId, new HashSet<ulong>());
						dbAndTables[item.Event.DbId].Add(item.Event.TId);
						tableAndData.TryAdd(item.Event.TId, new HashSet<BigInteger>());
						tableAndData[item.Event.TId].Add(item.Event.DId);
						dataAndHashs.TryAdd(item.Event.DId, (item.Event.PrevHash, item.Event.NextHash));
						sender = item.Event.Sender;
					}
					await Handler.DataModifiedEventHandler(dbAndTables, tableAndData, dataAndHashs);

					dbAndTables.Clear();
					tableAndData.Clear();
					dataAndHashs.Clear();
				}


				var log2 = await eventDataDeletedLog.GetAllChanges(filter2);

				if (ListEventDataDeletedLog.Count != log2.Count)
				{
					var dif = ListEventDataDeletedLog.Intersect(log2);

					var loop = dif.Except(log2);

					foreach (var item in loop)
					{
						dbAndTables.TryAdd(item.Event.DbId, new HashSet<ulong>());
						dbAndTables[item.Event.DbId].Add(item.Event.TId);
						tableAndData.TryAdd(item.Event.TId, new HashSet<BigInteger>());
						tableAndData[item.Event.TId].Add(item.Event.DId);
					}
					await Handler.DataDeletedEventHandler(dbAndTables, tableAndData);

					dbAndTables.Clear();
					tableAndData.Clear();
				}
			}
		}

	}
}
