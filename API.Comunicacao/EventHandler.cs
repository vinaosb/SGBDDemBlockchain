using API.SQL.Models;
using SharedLibrary.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using API.Comm.Controllers;

namespace API.Comunicacao
{
	public class EventHandlerBlockchain
	{
		public async Task DataModifiedEventHandler(Dictionary<uint, HashSet<ulong>> dbAndTables,
			Dictionary<ulong, HashSet<BigInteger>> tableAndData,
			Dictionary<BigInteger, (byte[], byte[])> dataAndHashs)
		{
			foreach (var db in dbAndTables)
			{
				foreach (var table in db.Value)
				{
					var t = Globals.TablesTypes[table].Name;
					foreach (var data in tableAndData.GetValueOrDefault(table))
					{
						switch (t)
						{
							case nameof(CensoEscola):
								CensoEscolasController cont = new CensoEscolasController();
								var gett = await cont.GetCensoEscola();
								var listCE = gett.Value;
								CensoEscola idd = null;
								foreach (var item in listCE)
								{
									idd = item;
									if (item.Id == data)
										break;
								}
								var putt = await cont.PutCensoEscola(idd.Ano, idd.CodEntidade, idd);
								break;
							case nameof(CorreioEletronico):
								CorreioEletronicoController cont2 = new CorreioEletronicoController();
								var gett2 = await cont2.GetCorreioEletronico();
								var listCE2 = gett2.Value;
								CorreioEletronico idd2 = null;
								foreach (var item in listCE2)
								{
									idd2 = item;
									if (item.Id == data)
										break;
								}
								var putt2 = await cont2.PutCorreioEletronico(idd2.Ano, idd2.CodEntidade, idd2);
								break;
							case nameof(Endereco):
								EnderecosController cont3 = new EnderecosController();
								var gett3 = await cont3.GetEndereco();
								var listCE3 = gett3.Value;
								Endereco idd3 = null;
								foreach (var item in listCE3)
								{
									idd3 = item;
									if (item.Id == data)
										break;
								}
								var putt3 = await cont3.PutEndereco(idd3.CodEndereco, idd3);
								break;
							case nameof(Escola):
								EscolasController cont4 = new EscolasController();
								var gett4 = await cont4.GetEscola();
								var listCE4 = gett4.Value;
								Escola idd4 = null;
								foreach (var item in listCE4)
								{
									idd4 = item;
									if (item.Id == data)
										break;
								}
								var putt4 = await cont4.PutEscola(idd4.CodEntidade, idd4);
								break;
							case nameof(Estado):
								EstadosController cont5 = new EstadosController();
								var gett5 = await cont5.GetEstado();
								var listCE5 = gett5.Value;
								Estado idd5 = null;
								foreach (var item in listCE5)
								{
									idd5 = item;
									if (item.Id == data)
										break;
								}
								var putt5 = await cont5.PutEstado(idd5.CodEstado, idd5);
								break;
							case nameof(ExtrasDaEscola):
								break;
							case nameof(MantenedoraDaEscola):
								MantenedorasDasEscolasController cont6 = new MantenedorasDasEscolasController();
								var gett6 = await cont6.GetMantenedoraDaEscola();
								var listCE6 = gett6.Value;
								MantenedoraDaEscola idd6 = null;
								foreach (var item in listCE6)
								{
									idd6 = item;
									if (item.Id == data)
										break;
								}
								var putt6 = await cont6.PutMantenedoraDaEscola(idd6.CodEntidade, idd6);
								break;
							case nameof(Municipio):
								MunicipiosController cont7 = new MunicipiosController();
								var gett7 = await cont7.GetMunicipio();
								var listCE7 = gett7.Value;
								Municipio idd7 = null;
								foreach (var item in listCE7)
								{
									idd7 = item;
									if (item.Id == data)
										break;
								}
								var putt7 = await cont7.PutMunicipio(idd7.CodMunicipio, idd7);
								break;
							case nameof(Regiao):
								RegioesController cont8 = new RegioesController();
								var gett8 = await cont8.GetRegiao();
								var listCE8 = gett8.Value;
								Regiao idd8 = null;
								foreach (var item in listCE8)
								{
									idd8 = item;
									if (item.Id == data)
										break;
								}
								var putt8 = await cont8.PutRegiao(idd8.CodRegiao, idd8);
								break;
							case nameof(Telefone):
								TelefonesController cont9 = new TelefonesController();
								var gett9 = await cont9.GetTelefone();
								var listCE9 = gett9.Value;
								Telefone idd9 = null;
								foreach (var item in listCE9)
								{
									idd9 = item;
									if (item.Id == data)
										break;
								}
								var putt9 = await cont9.PutTelefone(idd9.Numero, idd9.Ano, idd9.CodEntidade, idd9);
								break;
							default:
								break;
						}
					}
				}
			}
		}

		public async Task DataDeletedEventHandler(Dictionary<uint, HashSet<ulong>> dbAndTables, Dictionary<ulong, HashSet<BigInteger>> tableAndData)
		{
			foreach (var db in dbAndTables)
			{
				foreach (var table in db.Value)
				{
					var t = Globals.TablesTypes[table].Name;
					foreach (var data in tableAndData.GetValueOrDefault(table))
					{
						switch (t)
						{
							case nameof(CensoEscola):
								CensoEscolasController cont = new CensoEscolasController();
								var gett = await cont.GetCensoEscola();
								var listCE = gett.Value;
								CensoEscola idd = null;
								foreach (var item in listCE)
								{
									idd = item;
									if (item.Id == data)
										break;
								}
								var putt = await cont.DeleteCensoEscola(idd.Ano, idd.CodEntidade);
								break;
							case nameof(CorreioEletronico):
								CorreioEletronicoController cont2 = new CorreioEletronicoController();
								var gett2 = await cont2.GetCorreioEletronico();
								var listCE2 = gett2.Value;
								CorreioEletronico idd2 = null;
								foreach (var item in listCE2)
								{
									idd2 = item;
									if (item.Id == data)
										break;
								}
								var putt2 = await cont2.DeleteCorreioEletronico(idd2.Ano, idd2.CodEntidade);
								break;
							case nameof(Endereco):
								EnderecosController cont3 = new EnderecosController();
								var gett3 = await cont3.GetEndereco();
								var listCE3 = gett3.Value;
								Endereco idd3 = null;
								foreach (var item in listCE3)
								{
									idd3 = item;
									if (item.Id == data)
										break;
								}
								var putt3 = await cont3.DeleteEndereco(idd3.CodEndereco);
								break;
							case nameof(Escola):
								EscolasController cont4 = new EscolasController();
								var gett4 = await cont4.GetEscola();
								var listCE4 = gett4.Value;
								Escola idd4 = null;
								foreach (var item in listCE4)
								{
									idd4 = item;
									if (item.Id == data)
										break;
								}
								var putt4 = await cont4.DeleteEscola(idd4.CodEntidade);
								break;
							case nameof(Estado):
								EstadosController cont5 = new EstadosController();
								var gett5 = await cont5.GetEstado();
								var listCE5 = gett5.Value;
								Estado idd5 = null;
								foreach (var item in listCE5)
								{
									idd5 = item;
									if (item.Id == data)
										break;
								}
								var putt5 = await cont5.DeleteEstado(idd5.CodEstado);
								break;
							case nameof(ExtrasDaEscola):
								MongoController cont10 = new MongoController();
								var gett10 = await cont10.GetExtraAsync();
								var listCE10 = gett10.Value;
								ExtrasDaEscola idd10 = null;
								foreach (var item in listCE10)
								{
									idd10 = item;
									if (item.Id == data)
										break;
								}
								var putt10 = await cont10.DeleteExtra(idd10.ID.Ano, idd10.ID.Cod_Entidade);
								break;
							case nameof(MantenedoraDaEscola):
								MantenedorasDasEscolasController cont6 = new MantenedorasDasEscolasController();
								var gett6 = await cont6.GetMantenedoraDaEscola();
								var listCE6 = gett6.Value;
								MantenedoraDaEscola idd6 = null;
								foreach (var item in listCE6)
								{
									idd6 = item;
									if (item.Id == data)
										break;
								}
								var putt6 = await cont6.DeleteMantenedoraDaEscola(idd6.CodEntidade);
								break;
							case nameof(Municipio):
								MunicipiosController cont7 = new MunicipiosController();
								var gett7 = await cont7.GetMunicipio();
								var listCE7 = gett7.Value;
								Municipio idd7 = null;
								foreach (var item in listCE7)
								{
									idd7 = item;
									if (item.Id == data)
										break;
								}
								var putt7 = await cont7.DeleteMunicipio(idd7.CodMunicipio);
								break;
							case nameof(Regiao):
								RegioesController cont8 = new RegioesController();
								var gett8 = await cont8.GetRegiao();
								var listCE8 = gett8.Value;
								Regiao idd8 = null;
								foreach (var item in listCE8)
								{
									idd8 = item;
									if (item.Id == data)
										break;
								}
								var putt8 = await cont8.DeleteRegiao(idd8.CodRegiao);
								break;
							case nameof(Telefone):
								TelefonesController cont9 = new TelefonesController();
								var gett9 = await cont9.GetTelefone();
								var listCE9 = gett9.Value;
								Telefone idd9 = null;
								foreach (var item in listCE9)
								{
									idd9 = item;
									if (item.Id == data)
										break;
								}
								var putt9 = await cont9.DeleteTelefone(idd9.Numero, idd9.Ano, idd9.CodEntidade);
								break;
							default:
								break;
						}
					}
				}
			}
		}
	}
}
