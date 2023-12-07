namespace Entities.Exceptions;


 public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(int id) : base($"The Customer id {id} could not found")
        {
        }
    }
