using System;
using System.Collections.Generic;
using System.Numerics;

namespace API.Comunicacao
{
	public static class Globals
	{
		public static Dictionary<ulong, Type> TablesTypes = new Dictionary<ulong, Type>();
		public static HashSet<(uint, string)> Dbs = new HashSet<(uint, string)>();
		public static HashSet<ulong> Tables = new HashSet<ulong>();

		private static readonly Dictionary<uint, HashSet<ulong>> pdbAndTables = new Dictionary<uint, HashSet<ulong>>();

		public static Dictionary<uint, HashSet<ulong>> DbAndTables
		{
			get { return pdbAndTables; }
		}

		private static readonly Dictionary<ulong, HashSet<BigInteger>> ptableAndData = new Dictionary<ulong, HashSet<BigInteger>>();

		public static Dictionary<ulong, HashSet<BigInteger>> TableAndData
		{
			get { return ptableAndData; }
		}

		public static void AddTable(ulong tId, Type ty)
		{
			Tables.Add(tId);
			TablesTypes.Add(tId,ty);
			ptableAndData.Add(tId, new HashSet<BigInteger>());
		}
		public static void AddDB(uint dbId, string uri)
		{
			Dbs.Add((dbId, uri));
			pdbAndTables.Add(dbId, new HashSet<ulong>());
		}

		public static void AssocDbAndTable(uint dbId, ulong tId)
		{
			pdbAndTables[dbId].Add(tId);
		}

		public static void AssocTableAndData(ulong tId, BigInteger dId)
		{
			ptableAndData[tId].Add(dId);
		}

	}
}
