using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class EmprestimoService 
    {
        public void Inserir(Emprestimo e)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Emprestimos.Add(e);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Emprestimo e)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Emprestimo emprestimo = bc.Emprestimos.Find(e.Id);
                emprestimo.NomeUsuario = e.NomeUsuario;
                emprestimo.Telefone = e.Telefone;
                emprestimo.LivroId = e.LivroId;
                emprestimo.DataEmprestimo = e.DataEmprestimo;
                emprestimo.DataDevolucao = e.DataDevolucao;

                bc.SaveChanges();
            }
        }


public ICollection<Emprestimo> ListarTodos(FiltrosEmprestimos filtro = null)
{
    using (BibliotecaContext bc = new BibliotecaContext())
    {
        IQueryable<Emprestimo> query = bc.Emprestimos.Include(e => e.Livro);

        if (filtro != null)
        {
            // Define dinamicamente a filtragem com base no tipo de filtro
            if (!string.IsNullOrEmpty(filtro.TipoFiltro) && !string.IsNullOrEmpty(filtro.Filtro))
            {
                switch (filtro.TipoFiltro)
                {
                    case "Usuario":
                        query = query.Where(e => e.NomeUsuario.Contains(filtro.Filtro));
                        break;

                    case "Livro":
                        query = query.Where(e => e.Livro.Titulo.Contains(filtro.Filtro) || e.Livro.Autor.Contains(filtro.Filtro));
                        break;
                }
            }
        }

        // Ordena os resultados por data de devolução, ou outra coluna apropriada
        query = query.OrderBy(e => e.DataDevolucao);

        return query.ToList();
    }
}












    
        


        public Emprestimo ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Emprestimos.Find(id);
            }
        }
    }
}