pragma solidity >=0.5.1 <0.7.0;



contract BlockchainToBD {
    struct Attributes {
        uint256 attsId;
        uint64 numTables;
        mapping(uint64 => Table) tables;
    }
    
    struct Data {
        bytes32 hash;
        bool deleted;
        
        uint64 numTables;
        mapping(uint64 => Table) tables;
    }
    
    struct Table {
        uint128 numData;
        mapping(uint128 => Data) dataInTable;
        
        uint256 numAtt;
        mapping(uint256 => Attributes) atts;
        
        uint32 numDB;
        mapping(uint32 => DB) dbs;
    }
    
    
    struct DB {
        uint64 numTables;
        mapping(uint64 => Table) tablesInDB;
        
        bytes32 ipAdd;
        bytes32 typeOfDB;
    }
    
    uint256 numAtt;
    mapping(uint256 => Attributes) atts;
    uint32 numDB;
    mapping(uint32 => DB) dbs;
    mapping(address => uint32) dbsAddr;
    
    function verify(uint32 dbId, uint64 tId, uint128 dataId, bytes32 hash) public view returns (bool check) {
        if (dbs[dbId].tablesInDB[tId].dataInTable[dataId].hash == hash && !dbs[dbId].tablesInDB[tId].dataInTable[dataId].deleted)
            return true;
        return false;
    }
    
    function addDB(bytes32 IPAddress) public returns (uint32 dbId) {
        dbsAddr[msg.sender] = numDB;
        dbs[numDB].ipAdd = IPAddress;
		emit DbCreated(numDB, msg.sender);
        return numDB++;
    }
    
    function getIPAddr(address locate) public view returns (bytes32 ip) {
        return dbs[dbsAddr[locate]].ipAdd;
    }
    
    function addTable(uint32 dbId) public returns (uint64 tId) {
        dbs[dbId].tablesInDB[dbs[dbId].numTables].dbs[dbs[dbId].tablesInDB[dbs[dbId].numTables].numDB++] = dbs[dbId];
		emit TableCreated(numDB, dbs[dbId].numTables, msg.sender);
        return dbs[dbId].numTables++;
    }
    
    function addAttribute() public returns (uint256 AttCode) {
        atts[numAtt].attsId = numAtt;
		emit AttAdded(numAtt, msg.sender);
        return numAtt++;
    }
    
    function addData(uint32 dbId, uint64 tId, bytes32 dataHash) public returns (uint128 Id) {
        uint128 dataId = dbs[dbId].tablesInDB[tId].numData++;
        bytes32 prev = dbs[dbId].tablesInDB[tId].dataInTable[dataId].hash;
        dbs[dbId].tablesInDB[tId].dataInTable[dataId].hash = dataHash;
        dbs[dbId].tablesInDB[tId].dataInTable[dataId].deleted = false;
        emit DataModified(dbId, tId, dataId, msg.sender, prev, dataHash);
        return dataId;
    }
    
    function linkDataToAtt(uint32 dbId, uint64 tId, uint256 attId) public {
        atts[attId].tables[atts[attId].numTables++] = dbs[dbId].tablesInDB[tId];
        dbs[dbId].tablesInDB[tId].atts[dbs[dbId].tablesInDB[tId].numAtt++] = atts[attId];
    }
    
    function updateData(uint32 dbId, uint64 tId, uint128 dId, bytes32 dataHash, bytes32 prevHash) public returns (bool updated) {
        if (prevHash == dbs[dbId].tablesInDB[tId].dataInTable[dId].hash && !dbs[dbId].tablesInDB[tId].dataInTable[dId].deleted) {
            dbs[dbId].tablesInDB[tId].dataInTable[dId].hash = dataHash;
            for(uint256 i = 0; i < dbs[dbId].tablesInDB[tId].numAtt; i++) {
                uint256 attId = dbs[dbId].tablesInDB[tId].atts[i].attsId;
                
                for (uint64 k = 0; k < atts[attId].numTables; k++)
					for (uint32 l = 0; l < atts[attId].tables[k].numDB; l++)
                        emit DataModified(l, k, dId, msg.sender, prevHash, dataHash);
            }
            
            return true;
        }
        return false;
    }
    
    function deleteData(uint32 dbId, uint64 tId, uint128 dId, bytes32 dataHash) public returns (bool deleted) {
        if (dataHash == dbs[dbId].tablesInDB[tId].dataInTable[dId].hash && !dbs[dbId].tablesInDB[tId].dataInTable[dId].deleted) {
            dbs[dbId].tablesInDB[tId].dataInTable[dId].deleted = true;
            
            emit DataDeleted(dbId, tId, dId, msg.sender);
            
            return true;
        }
        return false;
    }
    
    function deleteDataFromAll(uint32 dbId, uint64 tId, uint128 dId, bytes32 dataHash) public returns (bool deleted) {
        if (dataHash == dbs[dbId].tablesInDB[tId].dataInTable[dId].hash && !dbs[dbId].tablesInDB[tId].dataInTable[dId].deleted) {
            dbs[dbId].tablesInDB[tId].dataInTable[dId].deleted = true;
            
            for(uint256 i = 0; i < dbs[dbId].tablesInDB[tId].numAtt; i++) {
                uint256 attId = dbs[dbId].tablesInDB[tId].atts[i].attsId;
                
                for (uint64 k = 0; k < atts[attId].numTables; k++)
					for (uint32 l = 0; l < atts[attId].tables[k].numDB; l++)
                        emit DataDeleted(l, k, dId, msg.sender);
            }
            return true;
        }
        return false;
    }
    
    event DataModified (
        uint32 indexed dbId,
        uint64 tId,
        uint128 dId,
        address sender,
        bytes32 prevHash,
        bytes32 nextHash
    );
    event DataDeleted (
        uint32 indexed dbId,
        uint64 tId,
        uint128 dId,
        address sender
    );
    event TableCreated (
        uint32 indexed dbId,
        uint64 tId,
        address sender
    );
    event DbCreated (
        uint32 indexed dbId,
        address sender
    );
    event AttAdded (
        uint256 indexed attId,
        address sender
    );
    
}