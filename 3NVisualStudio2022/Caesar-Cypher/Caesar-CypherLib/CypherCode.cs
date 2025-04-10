namespace Caesar_CypherLib
{
    public class CypherCode
    {
        private String _messageToCode;
        private char _key;

        public CypherCode(string messageToCode, char key)
        {
            _messageToCode = messageToCode;
            _key = key;
        }

        public string codeMessage()
        {
            int key = (int)_key;

            for (int i = 0; i < _messageToCode.Length; i++)
            {
                char letter = _messageToCode[i];
                char codedLetter = (char)(letter + key);
                _messageToCode = _messageToCode.Remove(i, 1).Insert(i, codedLetter.ToString());
            }

            return _messageToCode;

        }


    }
}
