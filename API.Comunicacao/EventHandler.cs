using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace API.Comunicacao
{
	public class EventHandlerBlockchain
	{
		public Task DataModifiedEventHandler(Dictionary<uint, HashSet<ulong>> dbAndTables, Dictionary<ulong, HashSet<BigInteger>> tableAndData, Dictionary<BigInteger, (byte[], byte[])> dataAndHashs)
		{
			if (Globals.dbAndTables.Count != dbAndTables)
			{

			}
		}

		public Task DataDeletedEventHandler(Dictionary<uint, HashSet<ulong>> dbAndTables, Dictionary<ulong, HashSet<BigInteger>> tableAndData)
		{
			throw new NotImplementedException();
		}
	}
}
