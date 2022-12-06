namespace BookPublisher.Domain.Constants
{
    public static class Validators
    {
        /* MESSAGES EMPTY BY USER */
        public const string MESSAGE_NAME_EMPTY = "O nome não pode ficar vazio. Por favor, insira um nome.";
        public const string MESSAGE_EMAIL_EMPTY = "O e-mail não pode ficar vazio. Por favor, insira um e-mail.";
        public const string MESSAGE_PASSWORD_EMPTY = "A senha não pode ficar vazia. Por favor, insira uma senha.";
        /* --- */

        /* MESSAGES NULL BY USER */
        public const string MESSAGE_NAME_NULL = "Por favor, insira um nome.";
        public const string MESSAGE_EMAIL_NULL = "Por favor, insira um e-mail.";
        public const string MESSAGE_PASSWORD_NULL = "Por favor, insira uma senha.";
        /* --- */

        public const string MESSAGE_INVALID_EMAIL = "O e-mail não atende aos requisitos. Por favor, insira um e-mail válido";
    }
}