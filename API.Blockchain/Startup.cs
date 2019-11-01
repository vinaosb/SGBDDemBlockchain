using API.Blockchain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;

namespace SGBDDemBlockchain
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public static BlockchainToBDService blockchainService { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public async void ConfigureServices(IServiceCollection services)
		{
			var account = new Account(Configuration.GetValue<string>("Ethereum:private"));
			var web3 = new Web3(account, Configuration.GetValue<string>("Ethereum:url"));
			var deploymentMessage = new BlockchainToBDDeployment();

			var deploymentHandler = web3.Eth.GetContractDeploymentHandler<BlockchainToBDDeployment>();
			var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
			var contractAddress = transactionReceipt.ContractAddress;

			blockchainService = new BlockchainToBDService(web3, contractAddress);

			_ = new EventPool(web3);

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
