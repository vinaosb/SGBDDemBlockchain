using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SharedLibrary.BlockchainToBD.ContractDefinition
{


    public partial class BlockchainToBDDeployment : BlockchainToBDDeploymentBase
    {
        public BlockchainToBDDeployment() : base(BYTECODE) { }
        public BlockchainToBDDeployment(string byteCode) : base(byteCode) { }
    }

    public class BlockchainToBDDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610d69806100206000396000f3fe608060405234801561001057600080fd5b506004361061009e5760003560e01c80636719f24b116100665780636719f24b146102135780638e7328da1461024b578063984d06021461029f578063ce35fbef146102de578063d728a321146103145761009e565b806314526bdc146100a357806323bf3fdf146100dd5780632bc40f9e1461013857806343edbeb51461017f5780634d7902d6146101cc575b600080fd5b6100db600480360360608110156100b957600080fd5b5063ffffffff813516906001600160401b03602082013516906040013561031c565b005b610124600480360360808110156100f357600080fd5b5063ffffffff813516906001600160401b03602082013516906001600160801b0360408201351690606001356103e8565b604080519115158252519081900360200190f35b6101246004803603608081101561014e57600080fd5b5063ffffffff813516906001600160401b03602082013516906001600160801b036040820135169060600135610524565b610124600480360360a081101561019557600080fd5b5063ffffffff813516906001600160401b03602082013516906001600160801b0360408201351690606081013590608001356105c4565b610124600480360360808110156101e257600080fd5b5063ffffffff813516906001600160401b03602082013516906001600160801b03604082013516906060013561080d565b6102396004803603602081101561022957600080fd5b50356001600160a01b0316610a46565b60408051918252519081900360200190f35b6102836004803603606081101561026157600080fd5b5063ffffffff813516906001600160401b036020820135169060400135610a77565b604080516001600160801b039092168252519081900360200190f35b6102c2600480360360208110156102b557600080fd5b503563ffffffff16610b3f565b604080516001600160401b039092168252519081900360200190f35b6102fb600480360360208110156102f457600080fd5b5035610c45565b6040805163ffffffff9092168252519081900360200190f35b610239610cdd565b63ffffffff92831660009081526003602081815260408084206001600160401b039687168552600190810183528185209585528083528185208082018054808a168085018b1667ffffffffffffffff199283161783558852600280840187528589208a5481546001600160801b0319166001600160801b03909116178155818b018054928201929092556004808c01549101805463ffffffff191691909d1617909b558a54808501909b5599875296909401909252909220905481559154910180549093169116179055565b63ffffffff841660009081526003602090815260408083206001600160401b0387168452600190810183528184206001600160801b0387168552019091528120548214801561047b575063ffffffff851660009081526003602090815260408083206001600160401b0388168452600190810183528184206001600160801b03881685528101909252909120015460ff16155b156105185763ffffffff851660008181526003602090815260408083206001600160401b038916808552600191820184528285206001600160801b038a168087529083018552948390208201805460ff1916909217909155815190815291820192909252338183015290517f1a5b63339aa5afa16a1f6deb8fb244dddb42be4e7e7d12f2df6d80ce3d155bd19181900360600190a250600161051c565b5060005b949350505050565b63ffffffff841660009081526003602090815260408083206001600160401b0387168452600190810183528184206001600160801b038716855201909152812054821480156105b7575063ffffffff851660009081526003602090815260408083206001600160401b0388168452600190810183528184206001600160801b03881685528101909252909120015460ff16155b156105185750600161051c565b63ffffffff851660009081526003602090815260408083206001600160401b0388168452600190810183528184206001600160801b03881685520190915281205482148015610657575063ffffffff861660009081526003602090815260408083206001600160401b0389168452600190810183528184206001600160801b03891685528101909252909120015460ff16155b156108005763ffffffff861660009081526003602090815260408083206001600160401b0389168452600190810183528184206001600160801b03891685520190915281208490555b63ffffffff871660009081526003602090815260408083206001600160401b038a1684526001019091529020600201548110156107f65763ffffffff871660009081526003602081815260408084206001600160401b038b16855260010182528084208585529092019052812054905b600082815260016020819052604090912001546001600160401b0390811690821610156107ec5760005b60008381526001602090815260408083206001600160401b038616845260020190915290206004015463ffffffff90811690821610156107e357604080516001600160401b03841681526001600160801b038a16602082015233818301526060810188905260808101899052905163ffffffff8316917fbac689f1c26106482b5b9247b6a96c3478851acf55187d7229443b5b68a448c9919081900360a00190a260010161073a565b50600101610710565b50506001016106a0565b5060019050610804565b5060005b95945050505050565b63ffffffff841660009081526003602090815260408083206001600160401b0387168452600190810183528184206001600160801b038716855201909152812054821480156108a0575063ffffffff851660009081526003602090815260408083206001600160401b0388168452600190810183528184206001600160801b03881685528101909252909120015460ff16155b156105185763ffffffff851660009081526003602090815260408083206001600160401b0388168452600190810183528184206001600160801b0388168552810190925282208101805460ff191690911790555b63ffffffff861660009081526003602090815260408083206001600160401b0389168452600101909152902060020154811015610a3c5763ffffffff861660009081526003602081815260408084206001600160401b038a16855260010182528084208585529092019052812054905b600082815260016020819052604090912001546001600160401b039081169082161015610a325760005b60008381526001602090815260408083206001600160401b038616845260020190915290206004015463ffffffff9081169082161015610a2957604080516001600160401b03841681526001600160801b03891660208201523381830152905163ffffffff8316917f1a5b63339aa5afa16a1f6deb8fb244dddb42be4e7e7d12f2df6d80ce3d155bd1919081900360600190a260010161098e565b50600101610964565b50506001016108f4565b506001905061051c565b6001600160a01b031660009081526004602090815260408083205463ffffffff168352600390915290206002015490565b63ffffffff831660008181526003602090815260408083206001600160401b0387168085526001918201845282852080546001600160801b031981166001600160801b03918216808601909216178255808752908301855283862080548982559301805460ff191690558351918252938101849052338184015260608101829052608081018790529151939492939092917fbac689f1c26106482b5b9247b6a96c3478851acf55187d7229443b5b68a448c99160a0918190039190910190a250949350505050565b63ffffffff808216600081815260036020818152604080842080546001600160401b03908116865260018083018552838720600481018054808c169384018c1663ffffffff1990911617905590875260050184528286208254815467ffffffffffffffff1916908316178155600280840154818301558387015491870191909155549686529383525481519316835233918301919091528051929493909316927f897935fa3da6255a945636b37478aa87abe77dcdaca39ec7d5e95561ca8ca97b92918290030190a25063ffffffff166000908152600360205260409020805467ffffffffffffffff19811660016001600160401b039283169081019092161790915590565b60028054336000818152600460209081526040808320805463ffffffff191663ffffffff9687161790558554851683526003825280832086018790559454855193845294519194909316927f19b602eb7a0e4e2db0c28161595fcbce9e24ef37994861a611d3c9abb69b6c16928290030190a250506002805463ffffffff198116600163ffffffff9283169081019092161790915590565b60008054808252600160209081526040808420839055805133815290517fad8ad935f9627047c2c668f8384b803260b72e7b761e58d56c24db577cfc7345929181900390910190a25060008054600181019091559056fea265627a7a7231582057e1272487dd427ad895ef4fdc460a0e16f8d970cb3e887bbf0a697a0039bffe64736f6c634300050b0032";
        public BlockchainToBDDeploymentBase() : base(BYTECODE) { }
        public BlockchainToBDDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class LinkDataToAttFunction : LinkDataToAttFunctionBase { }

    [Function("linkDataToAtt")]
    public class LinkDataToAttFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "dbId", 1)]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2)]
        public virtual ulong TId { get; set; }
        [Parameter("uint256", "attId", 3)]
        public virtual BigInteger AttId { get; set; }
    }

    public partial class DeleteDataFunction : DeleteDataFunctionBase { }

    [Function("deleteData", "bool")]
    public class DeleteDataFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "dbId", 1)]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2)]
        public virtual ulong TId { get; set; }
        [Parameter("uint128", "dId", 3)]
        public virtual BigInteger DId { get; set; }
        [Parameter("bytes32", "dataHash", 4)]
        public virtual byte[] DataHash { get; set; }
    }

    public partial class VerifyFunction : VerifyFunctionBase { }

    [Function("verify", "bool")]
    public class VerifyFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "dbId", 1)]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2)]
        public virtual ulong TId { get; set; }
        [Parameter("uint128", "dataId", 3)]
        public virtual BigInteger DataId { get; set; }
        [Parameter("bytes32", "hash", 4)]
        public virtual byte[] Hash { get; set; }
    }

    public partial class UpdateDataFunction : UpdateDataFunctionBase { }

    [Function("updateData", "bool")]
    public class UpdateDataFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "dbId", 1)]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2)]
        public virtual ulong TId { get; set; }
        [Parameter("uint128", "dId", 3)]
        public virtual BigInteger DId { get; set; }
        [Parameter("bytes32", "dataHash", 4)]
        public virtual byte[] DataHash { get; set; }
        [Parameter("bytes32", "prevHash", 5)]
        public virtual byte[] PrevHash { get; set; }
    }

    public partial class DeleteDataFromAllFunction : DeleteDataFromAllFunctionBase { }

    [Function("deleteDataFromAll", "bool")]
    public class DeleteDataFromAllFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "dbId", 1)]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2)]
        public virtual ulong TId { get; set; }
        [Parameter("uint128", "dId", 3)]
        public virtual BigInteger DId { get; set; }
        [Parameter("bytes32", "dataHash", 4)]
        public virtual byte[] DataHash { get; set; }
    }

    public partial class GetIPAddrFunction : GetIPAddrFunctionBase { }

    [Function("getIPAddr", "bytes32")]
    public class GetIPAddrFunctionBase : FunctionMessage
    {
        [Parameter("address", "locate", 1)]
        public virtual string Locate { get; set; }
    }

    public partial class AddDataFunction : AddDataFunctionBase { }

    [Function("addData", "uint128")]
    public class AddDataFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "dbId", 1)]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2)]
        public virtual ulong TId { get; set; }
        [Parameter("bytes32", "dataHash", 3)]
        public virtual byte[] DataHash { get; set; }
    }

    public partial class AddTableFunction : AddTableFunctionBase { }

    [Function("addTable", "uint64")]
    public class AddTableFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "dbId", 1)]
        public virtual uint DbId { get; set; }
    }

    public partial class AddDBFunction : AddDBFunctionBase { }

    [Function("addDB", "uint32")]
    public class AddDBFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "IPAddress", 1)]
        public virtual byte[] IPAddress { get; set; }
    }

    public partial class AddAttributeFunction : AddAttributeFunctionBase { }

    [Function("addAttribute", "uint256")]
    public class AddAttributeFunctionBase : FunctionMessage
    {

    }

    public partial class DataModifiedEventDTO : DataModifiedEventDTOBase { }

    [Event("DataModified")]
    public class DataModifiedEventDTOBase : IEventDTO
    {
        [Parameter("uint32", "dbId", 1, true )]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2, false )]
        public virtual ulong TId { get; set; }
        [Parameter("uint128", "dId", 3, false )]
        public virtual BigInteger DId { get; set; }
        [Parameter("address", "sender", 4, false )]
        public virtual string Sender { get; set; }
        [Parameter("bytes32", "prevHash", 5, false )]
        public virtual byte[] PrevHash { get; set; }
        [Parameter("bytes32", "nextHash", 6, false )]
        public virtual byte[] NextHash { get; set; }
    }

    public partial class DataDeletedEventDTO : DataDeletedEventDTOBase { }

    [Event("DataDeleted")]
    public class DataDeletedEventDTOBase : IEventDTO
    {
        [Parameter("uint32", "dbId", 1, true )]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2, false )]
        public virtual ulong TId { get; set; }
        [Parameter("uint128", "dId", 3, false )]
        public virtual BigInteger DId { get; set; }
        [Parameter("address", "sender", 4, false )]
        public virtual string Sender { get; set; }
    }

    public partial class TableCreatedEventDTO : TableCreatedEventDTOBase { }

    [Event("TableCreated")]
    public class TableCreatedEventDTOBase : IEventDTO
    {
        [Parameter("uint32", "dbId", 1, true )]
        public virtual uint DbId { get; set; }
        [Parameter("uint64", "tId", 2, false )]
        public virtual ulong TId { get; set; }
        [Parameter("address", "sender", 3, false )]
        public virtual string Sender { get; set; }
    }

    public partial class DbCreatedEventDTO : DbCreatedEventDTOBase { }

    [Event("DbCreated")]
    public class DbCreatedEventDTOBase : IEventDTO
    {
        [Parameter("uint32", "dbId", 1, true )]
        public virtual uint DbId { get; set; }
        [Parameter("address", "sender", 2, false )]
        public virtual string Sender { get; set; }
    }

    public partial class AttAddedEventDTO : AttAddedEventDTOBase { }

    [Event("AttAdded")]
    public class AttAddedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "attId", 1, true )]
        public virtual BigInteger AttId { get; set; }
        [Parameter("address", "sender", 2, false )]
        public virtual string Sender { get; set; }
    }





    public partial class VerifyOutputDTO : VerifyOutputDTOBase { }

    [FunctionOutput]
    public class VerifyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "check", 1)]
        public virtual bool Check { get; set; }
    }





    public partial class GetIPAddrOutputDTO : GetIPAddrOutputDTOBase { }

    [FunctionOutput]
    public class GetIPAddrOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "ip", 1)]
        public virtual byte[] Ip { get; set; }
    }








}
