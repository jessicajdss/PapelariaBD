using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD
{
    public class BancoDados
    {
        SqlConnection cn;

        SqlCommand comandos;

        SqlDataReader rd;

        public bool Adicionar(Categoria cat){
            bool rs = false;

            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress;Initial Catalog=Papelaria; user id=sa;password=senai@123"; //servidor, nome banco, usuario e senha
                cn.Open();
                comandos=new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text; // comandtype não vem da classe sql, vem de um pacote data
                comandos.CommandText = "insert into categorias(titulo)values(@vt)";//@ refere-se elemento parametro
                comandos.Parameters.AddWithValue("@vt",cat.Titulo);

                int r = comandos.ExecuteNonQuery();//momento que cadastra na base de dados, retorna um valor ao fazer a execução
                if (r>0)
                    rs = true;

                comandos.Parameters.Clear();
                Console.WriteLine("Cadastrado com sucesso!");
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar cadastrar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                cn.Close();
            }

            return rs;
        }

        public bool Atualizar(Categoria cat){
            bool rs = false;

            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress;Initial Catalog=Papelaria; user id=sa;password=senai@123"; //servidor, nome banco, usuario e senha
                cn.Open();
                comandos=new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text; // comandtype não vem da classe sql, vem de um pacote data
                comandos.CommandText = "update categorias set titulo = @vt where idCategoria=@vi";//@ refere-se elemento parametro
                comandos.Parameters.AddWithValue("@vt",cat.Titulo);
                comandos.Parameters.AddWithValue("@vi",cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();//momento que cadastra na base de dados, retorna um valor ao fazer a execução
                if (r>0)
                    rs = true;

                comandos.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar atualizar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                cn.Close();
            }

            return rs;
        }

        public bool Apagar(Categoria cat){
            bool rs = false;

            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress;Initial Catalog=Papelaria; user id=sa;password=senai@123"; //servidor, nome banco, usuario e senha
                cn.Open();
                comandos=new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text; // comandtype não vem da classe sql, vem de um pacote data
                comandos.CommandText = "delete from categorias where idCategoria=@vi";//@ refere-se elemento parametro
                comandos.Parameters.AddWithValue("@vi",cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();//momento que cadastra na base de dados, retorna um valor ao fazer a execução
                if (r>0)
                    rs = true;

                comandos.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar deletar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                cn.Close();
            }

            return rs;
        }

        public List<Categoria> ListarCategorias(int id){

            List<Categoria> lista = new List<Categoria>();
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress;Initial Catalog=Papelaria; user id=sa;password=senai@123"; //relação com o servidor, abrir o banco
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText="select * from categorias where idCategoria = @vi";
                comandos.Parameters.AddWithValue("@vi",id);
                rd = comandos.ExecuteReader();//não usa NonQuery porque ele retorna um valor numérico

                while(rd.Read()){
                    lista.Add(new Categoria{ //lista de Categorias. Ela foi tipada lá em cima como Categoria (classe)
                        IdCategoria=rd.GetInt32(0),
                        Titulo=rd.GetString(1)
                    });
                }
                comandos.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar listar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                cn.Close();
            }
            return lista;                   
        }

        public List<Categoria> ListarCategorias(string titulo){

            List<Categoria> lista = new List<Categoria>();
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress;Initial Catalog=Papelaria; user id=sa;password=senai@123"; //relação com o servidor, abrir o banco
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText="select * from categorias where titulo like @vt";
                comandos.Parameters.AddWithValue("@vt",titulo);
                rd = comandos.ExecuteReader();//não usa NonQuery porque ele retorna um valor numérico

                while(rd.Read()){
                    lista.Add(new Categoria{ //lista de Categorias. Ela foi tipada lá em cima como Categoria (classe)
                        IdCategoria=rd.GetInt32(0),
                        Titulo=rd.GetString(1)
                    });
                }
                comandos.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar listar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                cn.Close();
            }
            return lista;                   
        }

    }
}