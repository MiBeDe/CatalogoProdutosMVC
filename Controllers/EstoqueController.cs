using AutoMapper;
using CatalogoProdutosMVC.Helpers;
using CatalogoProdutosMVC.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdutosMVC.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public EstoqueController(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Listar(int pg=1)
        {
            var produtos = await _produtoRepository.GetProdutos(null, null);

            const int pageSize = 8;
            if (pg < 1)
                pg = 1;

            int recsCount = produtos.Count();

            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            var data = produtos.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;


            return View(data);
        }
    }
}
