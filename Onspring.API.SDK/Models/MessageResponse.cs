namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a response which includes a message.
    /// </summary>
    public class MessageResponse
    {
        /// <summary>
        /// Gets the message in the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="MessageResponse"/>.
        /// </summary>
        public MessageResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MessageResponse"/>.
        /// </summary>
        public MessageResponse(string message)
        {
            Message = message;
        }
    }
}
