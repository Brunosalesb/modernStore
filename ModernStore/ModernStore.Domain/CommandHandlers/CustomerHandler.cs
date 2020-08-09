using FluentValidator;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.CommandHandlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<UpdateCustomerCommand>, ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public void Handle(UpdateCustomerCommand command)
        {
            var customer = _customerRepository.GetByUserId(command.Id);

            if (customer == null)
            {
                AddNotification("Customer", "Cliente não encontrado");
                return;
            }

            var name = new Name(command.FirstName, command.LastName);
            customer.Update(name, command.BirthDate);

            AddNotifications(customer.Notifications);

            if (IsValid())
                _customerRepository.Update(customer);
        }

        public void Handle(RegisterCustomerCommand command)
        {
            //verifica se ja existe o CPF
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }

            //gera novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email, document, user);

            //add notificacoes
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            //inserir no banco
            if (IsValid())
                _customerRepository.Save(customer);

            //enviar email
            _emailService.Send(customer.Name.ToString(), customer.Email.Address, "Bem vindo", "");

        }
    }
}
