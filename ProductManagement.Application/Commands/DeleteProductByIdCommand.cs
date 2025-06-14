using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

namespace ProductManagement.ProductManagement.Application.Commands;

public class DeleteProductByIdCommand : IRequest<int>
{
    public int Id { get; set; }
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private ProductContext context;
        public DeleteProductByIdCommandHandler(ProductContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await context.Product.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            context.Product.Remove(product);
            await context.SaveChangesAsync();
            return product.Id;
        }
    }
}
