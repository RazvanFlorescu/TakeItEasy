using BusinessLogicCommon.CqrsCore.Commands;

namespace BusinessLogicWriter.CqrsCore.Commands.Email
{
    public class SendEmailCommand : ICommand
    {
        public string AuthorEmail { get; }
        public string DestinatorEmail { get; }
        public string Message { get; } 
        public string FirstName { get; }
        public string LastName { get; }

        public SendEmailCommand(string authorEmail, string destinatorEmail, string message, string firstName, string lastName)
        {
            AuthorEmail = authorEmail;
            DestinatorEmail = destinatorEmail;
            Message = message;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
