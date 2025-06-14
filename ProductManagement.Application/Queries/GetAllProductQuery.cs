using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

namespace ProductManagement.ProductManagement.Application.Queries;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private ProductContext context;
        public GetAllProductQueryHandler(ProductContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
        {
            var productList = await context.Product.ToListAsync();
            return productList;
        }
    }
}
