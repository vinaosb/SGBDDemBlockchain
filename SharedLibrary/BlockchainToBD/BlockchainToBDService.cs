using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SharedLibrary.BlockchainToBD.ContractDefinition;

namespace SharedLibrary.BlockchainToBD
{
    public partial class BlockchainToBDService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BlockchainToBDDeployment blockchainToBDDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BlockchainToBDDeployment>().SendRequestAndWaitForReceiptAsync(blockchainToBDDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BlockchainToBDDeployment blockchainToBDDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BlockchainToBDDeployment>().SendRequestAsync(blockchainToBDDeployment);
        }

        public static async Task<BlockchainToBDService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BlockchainToBDDeployment blockchainToBDDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, blockchainToBDDeployment, cancellationTokenSource);
            return new BlockchainToBDService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BlockchainToBDService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> LinkDataToAttRequestAsync(LinkDataToAttFunction linkDataToAttFunction)
        {
             return ContractHandler.SendRequestAsync(linkDataToAttFunction);
        }

        public Task<TransactionReceipt> LinkDataToAttRequestAndWaitForReceiptAsync(LinkDataToAttFunction linkDataToAttFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(linkDataToAttFunction, cancellationToken);
        }

        public Task<string> LinkDataToAttRequestAsync(uint dbId, ulong tId, BigInteger attId)
        {
            var linkDataToAttFunction = new LinkDataToAttFunction();
                linkDataToAttFunction.DbId = dbId;
                linkDataToAttFunction.TId = tId;
                linkDataToAttFunction.AttId = attId;
            
             return ContractHandler.SendRequestAsync(linkDataToAttFunction);
        }

        public Task<TransactionReceipt> LinkDataToAttRequestAndWaitForReceiptAsync(uint dbId, ulong tId, BigInteger attId, CancellationTokenSource cancellationToken = null)
        {
            var linkDataToAttFunction = new LinkDataToAttFunction();
                linkDataToAttFunction.DbId = dbId;
                linkDataToAttFunction.TId = tId;
                linkDataToAttFunction.AttId = attId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(linkDataToAttFunction, cancellationToken);
        }

        public Task<string> DeleteDataRequestAsync(DeleteDataFunction deleteDataFunction)
        {
             return ContractHandler.SendRequestAsync(deleteDataFunction);
        }

        public Task<TransactionReceipt> DeleteDataRequestAndWaitForReceiptAsync(DeleteDataFunction deleteDataFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteDataFunction, cancellationToken);
        }

        public Task<string> DeleteDataRequestAsync(uint dbId, ulong tId, BigInteger dId, byte[] dataHash)
        {
            var deleteDataFunction = new DeleteDataFunction();
                deleteDataFunction.DbId = dbId;
                deleteDataFunction.TId = tId;
                deleteDataFunction.DId = dId;
                deleteDataFunction.DataHash = dataHash;
            
             return ContractHandler.SendRequestAsync(deleteDataFunction);
        }

        public Task<TransactionReceipt> DeleteDataRequestAndWaitForReceiptAsync(uint dbId, ulong tId, BigInteger dId, byte[] dataHash, CancellationTokenSource cancellationToken = null)
        {
            var deleteDataFunction = new DeleteDataFunction();
                deleteDataFunction.DbId = dbId;
                deleteDataFunction.TId = tId;
                deleteDataFunction.DId = dId;
                deleteDataFunction.DataHash = dataHash;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteDataFunction, cancellationToken);
        }

        public Task<bool> VerifyQueryAsync(VerifyFunction verifyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VerifyFunction, bool>(verifyFunction, blockParameter);
        }

        
        public Task<bool> VerifyQueryAsync(uint dbId, ulong tId, BigInteger dataId, byte[] hash, BlockParameter blockParameter = null)
        {
            var verifyFunction = new VerifyFunction();
                verifyFunction.DbId = dbId;
                verifyFunction.TId = tId;
                verifyFunction.DataId = dataId;
                verifyFunction.Hash = hash;
            
            return ContractHandler.QueryAsync<VerifyFunction, bool>(verifyFunction, blockParameter);
        }

        public Task<string> UpdateDataRequestAsync(UpdateDataFunction updateDataFunction)
        {
             return ContractHandler.SendRequestAsync(updateDataFunction);
        }

        public Task<TransactionReceipt> UpdateDataRequestAndWaitForReceiptAsync(UpdateDataFunction updateDataFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateDataFunction, cancellationToken);
        }

        public Task<string> UpdateDataRequestAsync(uint dbId, ulong tId, BigInteger dId, byte[] dataHash, byte[] prevHash)
        {
            var updateDataFunction = new UpdateDataFunction();
                updateDataFunction.DbId = dbId;
                updateDataFunction.TId = tId;
                updateDataFunction.DId = dId;
                updateDataFunction.DataHash = dataHash;
                updateDataFunction.PrevHash = prevHash;
            
             return ContractHandler.SendRequestAsync(updateDataFunction);
        }

        public Task<TransactionReceipt> UpdateDataRequestAndWaitForReceiptAsync(uint dbId, ulong tId, BigInteger dId, byte[] dataHash, byte[] prevHash, CancellationTokenSource cancellationToken = null)
        {
            var updateDataFunction = new UpdateDataFunction();
                updateDataFunction.DbId = dbId;
                updateDataFunction.TId = tId;
                updateDataFunction.DId = dId;
                updateDataFunction.DataHash = dataHash;
                updateDataFunction.PrevHash = prevHash;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateDataFunction, cancellationToken);
        }

        public Task<string> DeleteDataFromAllRequestAsync(DeleteDataFromAllFunction deleteDataFromAllFunction)
        {
             return ContractHandler.SendRequestAsync(deleteDataFromAllFunction);
        }

        public Task<TransactionReceipt> DeleteDataFromAllRequestAndWaitForReceiptAsync(DeleteDataFromAllFunction deleteDataFromAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteDataFromAllFunction, cancellationToken);
        }

        public Task<string> DeleteDataFromAllRequestAsync(uint dbId, ulong tId, BigInteger dId, byte[] dataHash)
        {
            var deleteDataFromAllFunction = new DeleteDataFromAllFunction();
                deleteDataFromAllFunction.DbId = dbId;
                deleteDataFromAllFunction.TId = tId;
                deleteDataFromAllFunction.DId = dId;
                deleteDataFromAllFunction.DataHash = dataHash;
            
             return ContractHandler.SendRequestAsync(deleteDataFromAllFunction);
        }

        public Task<TransactionReceipt> DeleteDataFromAllRequestAndWaitForReceiptAsync(uint dbId, ulong tId, BigInteger dId, byte[] dataHash, CancellationTokenSource cancellationToken = null)
        {
            var deleteDataFromAllFunction = new DeleteDataFromAllFunction();
                deleteDataFromAllFunction.DbId = dbId;
                deleteDataFromAllFunction.TId = tId;
                deleteDataFromAllFunction.DId = dId;
                deleteDataFromAllFunction.DataHash = dataHash;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteDataFromAllFunction, cancellationToken);
        }

        public Task<byte[]> GetIPAddrQueryAsync(GetIPAddrFunction getIPAddrFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetIPAddrFunction, byte[]>(getIPAddrFunction, blockParameter);
        }

        
        public Task<byte[]> GetIPAddrQueryAsync(string locate, BlockParameter blockParameter = null)
        {
            var getIPAddrFunction = new GetIPAddrFunction();
                getIPAddrFunction.Locate = locate;
            
            return ContractHandler.QueryAsync<GetIPAddrFunction, byte[]>(getIPAddrFunction, blockParameter);
        }

        public Task<string> AddDataRequestAsync(AddDataFunction addDataFunction)
        {
             return ContractHandler.SendRequestAsync(addDataFunction);
        }

        public Task<TransactionReceipt> AddDataRequestAndWaitForReceiptAsync(AddDataFunction addDataFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addDataFunction, cancellationToken);
        }

        public Task<string> AddDataRequestAsync(uint dbId, ulong tId, byte[] dataHash)
        {
            var addDataFunction = new AddDataFunction();
                addDataFunction.DbId = dbId;
                addDataFunction.TId = tId;
                addDataFunction.DataHash = dataHash;
            
             return ContractHandler.SendRequestAsync(addDataFunction);
        }

        public Task<TransactionReceipt> AddDataRequestAndWaitForReceiptAsync(uint dbId, ulong tId, byte[] dataHash, CancellationTokenSource cancellationToken = null)
        {
            var addDataFunction = new AddDataFunction();
                addDataFunction.DbId = dbId;
                addDataFunction.TId = tId;
                addDataFunction.DataHash = dataHash;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addDataFunction, cancellationToken);
        }

        public Task<string> AddTableRequestAsync(AddTableFunction addTableFunction)
        {
             return ContractHandler.SendRequestAsync(addTableFunction);
        }

        public Task<TransactionReceipt> AddTableRequestAndWaitForReceiptAsync(AddTableFunction addTableFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addTableFunction, cancellationToken);
        }

        public Task<string> AddTableRequestAsync(uint dbId)
        {
            var addTableFunction = new AddTableFunction();
                addTableFunction.DbId = dbId;
            
             return ContractHandler.SendRequestAsync(addTableFunction);
        }

        public Task<TransactionReceipt> AddTableRequestAndWaitForReceiptAsync(uint dbId, CancellationTokenSource cancellationToken = null)
        {
            var addTableFunction = new AddTableFunction();
                addTableFunction.DbId = dbId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addTableFunction, cancellationToken);
        }

        public Task<string> AddDBRequestAsync(AddDBFunction addDBFunction)
        {
             return ContractHandler.SendRequestAsync(addDBFunction);
        }

        public Task<TransactionReceipt> AddDBRequestAndWaitForReceiptAsync(AddDBFunction addDBFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addDBFunction, cancellationToken);
        }

        public Task<string> AddDBRequestAsync(byte[] iPAddress)
        {
            var addDBFunction = new AddDBFunction();
                addDBFunction.IPAddress = iPAddress;
            
             return ContractHandler.SendRequestAsync(addDBFunction);
        }

        public Task<TransactionReceipt> AddDBRequestAndWaitForReceiptAsync(byte[] iPAddress, CancellationTokenSource cancellationToken = null)
        {
            var addDBFunction = new AddDBFunction();
                addDBFunction.IPAddress = iPAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addDBFunction, cancellationToken);
        }

        public Task<string> AddAttributeRequestAsync(AddAttributeFunction addAttributeFunction)
        {
             return ContractHandler.SendRequestAsync(addAttributeFunction);
        }

        public Task<string> AddAttributeRequestAsync()
        {
             return ContractHandler.SendRequestAsync<AddAttributeFunction>();
        }

        public Task<TransactionReceipt> AddAttributeRequestAndWaitForReceiptAsync(AddAttributeFunction addAttributeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAttributeFunction, cancellationToken);
        }

        public Task<TransactionReceipt> AddAttributeRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<AddAttributeFunction>(null, cancellationToken);
        }
    }
}
