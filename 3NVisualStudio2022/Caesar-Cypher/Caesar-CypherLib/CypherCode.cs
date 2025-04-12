namespace Caesar_CypherLib
{
    public class CypherCode
    {
        private String _messageToCode;
        private int _key;

        public CypherCode(string messageToCode, int key)
        {

           
            if(key < 1 || key > 26)
                throw new ArgumentException("Key must be between 1 and 26");

            if (messageToCode.Length == 0)
                throw new ArgumentException("Message to code must be at least 1 character long");

            _messageToCode = messageToCode;
            _key = key;
        }

        //code the message only with alphabetic characters
        public string codeMessage()
        {
            string codedMessage = "";
            foreach (char c in _messageToCode)
            {
                if (char.IsNumber(c))
                {
                    if ((int)c + _key > 57)
                    {
                        codedMessage += (char)((int)c + _key - 10);
                    }
                    else
                    {
                        codedMessage += (char)((int)c + _key);
                    }
                }
                else if (char.IsUpper(c) && (int)c + _key > 90)
                {
                    codedMessage += (char)((int)c + _key - 26);
                }
                else if (char.IsLower(c) && (int)c + _key > 122)
                {
                    codedMessage += (char)((int)c + _key - 26);
                }
                else
                {                     
                    codedMessage += (char)((int)c + _key);
                }
                
            }
            return codedMessage;
        }

        public string decodeMessage()
        {
            string decodedMessage = "";
            foreach (char c in _messageToCode)
            {
                if (char.IsNumber(c))
                {
                    if ((int)c - _key < 48)
                    {
                        decodedMessage += (char)((int)c - _key + 10);
                    }
                    else
                    {
                        decodedMessage += (char)((int)c - _key);
                    }
                }
                else if (char.IsLetter(c))
                { 
                    if (char.IsUpper(c) && (int)c - _key < 65)
                    {
                        decodedMessage += (char)((int)c - _key + 26);
                    }
                    else if (char.IsLower(c) && (int)c - _key < 97)
                    {
                        decodedMessage += (char)((int)c - _key + 26);
                    }
                    else
                    {
                        decodedMessage += (char)((int)c - _key);
                    }
                }
                else
                {
                    decodedMessage += (char)((int)c - _key);
                }

            }
            return decodedMessage;
        }

        




    }
}
