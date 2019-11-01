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
			throw new NotImplementedException();
		}

		public Task DataDeletedEventHandler(Dictionary<uint, HashSet<ulong>> dbAndTables, Dictionary<ulong, HashSet<BigInteger>> tableAndData)
		{
			throw new NotImplementedException();
		}
	}
}
