namespace AoC
{
    public static class Helper
    {
        private const char CHAR_ZERO = '0';
        private const char CHAR_LOWERCASE_A = 'a';

        private static int BytesToInt(byte pos, byte size, byte[] buffer)
        {
            int val = 0;
            int max = pos + size;

            for (byte index = pos; index < max; index++)
            {
                val *= 10;
                val += buffer[index] - CHAR_ZERO;
            }

            return val;
        }

        public static byte[] IntToBytes(int value)
        {
            if (value == 0)
            {
                return new[] {(byte) 48};
            }

            int localCopy = value;
            int numberOfDigits = 0;

            while (localCopy > 0)
            {
                localCopy /= 10;
                numberOfDigits++;
            }

            byte[] bytes = new byte[numberOfDigits];
            int counter = bytes.Length - 1;

            while (value > 0)
            {
                byte rightmost = (byte) (value%10 + CHAR_ZERO);
                value /= 10;
                bytes[counter--] = rightmost;
            }

            return bytes;
        }

        public static char[] ByteArrayToCharArray(byte[] bytes)
        {
            char[] result = new char[bytes.Length*2];

            int counter = 0;

            for (int index = 0; index < result.Length; index += 2)
            {
                byte b = bytes[counter++];
                result[index] = GetHexValue(b/16);
                result[index + 1] = GetHexValue(b%16);
            }

            return result;
        }

        private static char GetHexValue(int i)
        {
            if (i < 10)
            {
                return (char) (i + CHAR_ZERO);
            }

            return (char) (i - 10 + CHAR_LOWERCASE_A);
        }
    }
}