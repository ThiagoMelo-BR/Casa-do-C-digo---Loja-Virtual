using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(Pedido pedido)
        {
            Pedido = pedido;
            Itens = pedido.Itens;
        }

        public Pedido Pedido { get; }

        public IList<ItemPedido> Itens;

        public decimal Total
        {
            get
            {
                return Pedido.Total;
            }
        }
    }
}
