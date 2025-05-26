namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(OrderDto Order)
    : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Order).NotNull();
        RuleFor(x => x.Order.OrderName).NotEmpty().MaximumLength(100).WithMessage("Name is required");
        RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("Customer Id is required");
        RuleForEach(x => x.Order.OrderItems).NotEmpty().WithMessage("Order Itens shoud not be null");
    }
}

