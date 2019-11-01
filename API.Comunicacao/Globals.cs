using System.Collections.Generic;
using System.Numerics;

namespace API.Comunicacao
{
	public static class Globals
	{
		public static HashSet<(uint, string)> Dbs = new HashSet<(uint, string)>();
		public static HashSet<ulong> Tables = new HashSet<ulong>();

		private static readonly Dictionary<uint, HashSet<ulong>> pdbAndTables = new Dictionary<uint, HashSet<ulong>>();

		public static Dictionary<uint, HashSet<ulong>> dbAndTables
		{
			get { return pdbAndTables; }
		}

		private static readonly Dictionary<ulong, HashSet<BigInteger>> ptableAndData = new Dictionary<uint, HashSet<BigInteger>>();

		public static Dictionary<ulong, HashSet<BigInteger>> tableAndData
		{
			get { return ptableAndData; }
		}

		public static void addTable(ulong tId)
		{
			Tables.Add(tId);
			ptableAndData.Add(tId, new HashSet<BigInteger>());
		}
		public static void addDB(uint dbId, string uri)
		{
			Dbs.Add((dbId, uri));
			pdbAndTables.Add(dbId, new HashSet<ulong>());
		}

		public static void assocDbAndTable(uint dbId, ulong tId)
		{
			pdbAndTables[dbId].Add(tId);
		}

		public static assocTableAndData(ulong tId, BigInteger dId)
		{
			ptableAndData[tId].Add(dId);
		}

	}
}
