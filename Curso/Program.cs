using CursoEFCore.Domain;
using CursoEFCore.Data;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;


public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Iniciando Migração pendente.");
		//InserirProduto();
		//InserirDadosEmMassa();
		ConsultarDados();


		// Verifica se há migrações pendentes
		//using var db = new ApplicationContext(); // Use o nome correto da classe
		//var existe = db.Database.GetPendingMigrations().Any();
		//if (existe)
		//{}
		//else
		//{}
	}

	private static void InserirProduto()
	{
		var produto = new Produto
		{
			Descricao = "Produto Teste",
			CodigoBarras = "134DAQD234",
			Valor = 3.45m,
			TipoProduto = CursoEFCore.ValueObjects.TipoProduto.Embalagem,
			Ativo = true,
		};

		using var db = new AplicationContext();
		db.Produtos.Add(produto); 
		var registros = db.SaveChanges();
		Console.WriteLine($"Total de registros: {registros}");
	}


	private static void InserirDadosEmMassa()
	{
		var produto = new Produto
		{
			Descricao = "Produto Massa",
			CodigoBarras = "134DAQD2323",
			Valor = 3.35m,
			TipoProduto = CursoEFCore.ValueObjects.TipoProduto.MercadoriaParaRevenda,
			Ativo = true,
		};

		var cliente = new Cliente
		{
			Nome = "Joao da silva",
			Email = "joaoMassa@gmail.com",
			CEP = "88811700",
			Cidade = "Criciuma",
			Estado = "SC",
			Telefone = "9923251"
		};


		var listaClientes = new[]
		{
			new Cliente
			{
				Nome = "Carlos Souza",
				Email = "carlos.souza@example.com",
				CEP = "87654321",
				Cidade = "Rio de Janeiro",
				Estado = "RJ",
				Telefone = "123456789"
			},
			new Cliente
			{
				Nome = "Maria Oliveira",
				Email = "maria.oliveira@example.com",
				CEP = "12345678",
				Cidade = "São Paulo",
				Estado = "SP",
				Telefone = "987654321"
			}
		}; 


		using var db = new AplicationContext();
		db.AddRange(listaClientes);
		var registros = db.SaveChanges();
		Console.WriteLine($"Total de registros salvos: {registros}");
	}


	private static void ConsultarDados()
	{
		using var db = new AplicationContext();
		var consultaPorMetodos = db.Clientes
			.AsNoTracking()
			.Where(p => p.Id>0)
			.OrderBy(p => p.Id)
			.ToList();
		
		Console.WriteLine($"Consultando cliente:");
		foreach (var cliente in consultaPorMetodos)
		{
			Console.WriteLine($"Id: {cliente.Id} - Nome: {cliente.Nome}");
			//db.Clientes.Find(cliente.Id);
			db.Clientes.FirstOrDefault(p => p.Id==cliente.Id);
		}
	}
}