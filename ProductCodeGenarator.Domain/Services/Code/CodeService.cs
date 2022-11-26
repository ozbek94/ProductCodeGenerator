using System.Text;

namespace ProductCodeGenarator.Domain.Services.Code
{
    public class CodeService : ICodeService
    {
        public async Task<bool> CheckCode(string Code)
        {
            var codeArray = Code.ToCharArray();
            for (int i = 0; i < codeArray.Length-1; i++)
            {
                if(codeArray[i]+1 == codeArray[i+1])
                {
                    return false;
                }
            }

            if (codeArray.Length > 8 || codeArray.Length < 8)
            {
                return false;
            }
            return true;
        }

        public async Task<List<string>> GenerateCodes(int Count)
        {
            Random random = new Random();
            string chars = "ACDEFGHKLMNPRTXYZ234579";
            var sortedChars = chars.OrderBy(x => x); // ardışık karakter kontrolü için küçükten büyüğe karakterleri sıraladım.
            var charsArray = sortedChars.ToArray();
            List<string> codeList = new List<string>();

            StringBuilder sb = new StringBuilder(); //Karakterler üzerinde döngüsel bi değişiklik olduğu için SB tercih ettim. 

            CodeGenerator(Count, random, charsArray, codeList, sb);

            return codeList;
        }

        private void CodeGenerator(
            int Count, 
            Random random,
            char[] charsArray,
            List<string> codeList, StringBuilder sb)
        {
            int oldValue = -1;
            for (int codeCount = 0; codeCount < Count;)
            {
                for (int codeIndex = 0; codeIndex < 8; codeIndex++)
                {
                    int value;
                    while (true)
                    {
                        value = random.Next(0, charsArray.Length);
                        if (oldValue != value - 1 || oldValue != value + 1)     // Ardışık karakter kontrolü
                        {
                            oldValue = value;
                            break;
                        }
                    }

                    sb.Append(charsArray[value]);
                }

                if (!codeList.Equals(sb.ToString()))                //
                {                                                   //Eşsizlik kontrolü
                    codeList.Add(sb.ToString());                    //
                    codeCount++;
                }
                sb.Clear();
            }
        }
    }
}
