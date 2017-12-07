using System;
using System.Collections.Generic;

namespace ExemploCRUD
{
    class Program
    {
        /*
        1 - instanciar classe bd 
        2 - instanciar classe categoria
        3 - obter titulo categoria
        4 - definir titulo objeto categoria
        5 - chamar metodo adicionar objeto banco dados 
      
        */
        static void Main(string[] args)
        {
            int opcao = 0 ; 
            int opcao_atividade = 0;
            string item_categoria = "";
            int id_categoria = 0;
       
            BancoDados bd = new BancoDados();                    
            Categoria categ = new Categoria();

            while (opcao != 9) {
                Console.WriteLine("\n ===== New Paper * papelaria ====== \n");
                Console.WriteLine("1 - Clientes\n2 - Categorias\n3 - Produtos\n4 - Estoque\n5 - Usuários\n9 - Sair\n");
                opcao = Int16.Parse(Console.ReadLine());
                
                switch(opcao){
                    case 1:
                        Console.WriteLine("\nEscolha o tipo de atividade que deseja realizar com Clientes: ");
                        Console.WriteLine("1 - Cadastrar\n2 - Consultar\n3 - Atualizar\n4 - Excluir\n9 - Sair\n");
                        
                        

                        break;                        

                    case 2:
                        Console.WriteLine("Escolha o tipo de atividade que deseja realizar com Categorias: ");
                        Console.WriteLine("1 - Cadastrar\n2 - Consultar\n3 - Atualizar\n4 - Excluir\n9 - Sair\n");
                        opcao_atividade = Int16.Parse(Console.ReadLine());
                        
                        switch (opcao_atividade){
                            case 1:
                                Console.WriteLine("Informe uma nova Categoria para os itens da papelaria: ");
                                item_categoria = Console.ReadLine(); 
                                categ.Titulo= item_categoria;
                                bd.Adicionar(categ);
                                break;
                            
                            case 2:
                                Console.WriteLine("Informe a Categoria que deseja consultar: ");
                                item_categoria = Console.ReadLine(); 
                                
                                List<Categoria> lista = bd.ListarCategorias(item_categoria);                                           

                                foreach(var item in lista){                    
                                    Console.WriteLine("\n"+item.IdCategoria+" - "+item.Titulo);
                                }
                                break;

                            case 3:
                                Console.WriteLine("Informe o id da Categoria que deseja atualizar: ");
                                id_categoria = Int16.Parse(Console.ReadLine());

                                Console.WriteLine("Informe o novo titulo/nome dessa Categoria: ");
                                item_categoria = Console.ReadLine(); 
                                
                                categ.IdCategoria = id_categoria;
                                categ.Titulo= item_categoria;

                                bd.Atualizar(categ);
                                break;

                            case 4:
                                Console.WriteLine("Informe o id da Categoria que deseja excluir: ");
                                id_categoria = Int16.Parse(Console.ReadLine());

                                categ.IdCategoria = id_categoria;
                                bd.Apagar(categ);
                                
                                break;
                             
                            case 9:
                                Console.WriteLine("Saindo do sistema.");
                                break;
                    
                            default:
                                break;  
                        }

                        break; 

                    case 3:
                        Console.WriteLine("Informe o Id da Categoria que deseja atualizar: ");
                        id_categoria = Int16.Parse(Console.ReadLine());
                        Console.WriteLine("Informe o novo título da Categoria que deseja atualizar: ");
                        item_categoria = Console.ReadLine();
                        categ.IdCategoria = id_categoria;
                        categ.Titulo = item_categoria;                        

                        break;  
                        
                    case 4:
                        Console.WriteLine("Informe a Categoria que deseja deletar: ");

                        break;                                   
                
                        
                    case 9:
                        Console.WriteLine("Saindo do sistema.");
                        break;
                    
                    default:
                        break;               
                           
                }
            }
            

            



        }
    }
}
