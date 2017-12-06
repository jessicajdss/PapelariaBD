using System;

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
            string item_categoria = "";
            int id_categoria = 0;
       
            BancoDados bd = new BancoDados();                    
            Categoria categ = new Categoria();

            while (opcao != 9) {
                Console.WriteLine("\n ===== New Paper * papelaria ====== \n");
                Console.WriteLine("1 - Cadastro\n2 - Consulta\n3 - Atualização\n4 - Deletar\n\n9 - Sair\n");
                opcao = Int16.Parse(Console.ReadLine());
                
                switch(opcao){
                    case 1:
                        Console.WriteLine("Informe uma nova Categoria para os itens da papelaria: ");
                        item_categoria = Console.ReadLine(); 
                        categ.Titulo= item_categoria;
                        bd.Adicionar(categ);
                        break;

                    case 2:
                        Console.WriteLine("Informe a Categoria que deseja consultar: ");
                        item_categoria = Console.ReadLine(); 
                        //categ.Titulo=item_categoria;
                        bd.ListarCategorias(item_categoria);
                                           

                        foreach(var item in ){ 
                
                            string c = item.GetType().ToString();
 
                                    Console.WriteLine("Categoria: "+categ.Titulo+" - "+categ.IdCategoria);

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
