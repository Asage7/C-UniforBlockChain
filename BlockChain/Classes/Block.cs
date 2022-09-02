using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Block
    {
        public readonly DateTime _timeStamp;
        public int Index;
        public long _nonce;
        public string PreviousHash { get; set; }
        public Content Content { get; set; }
        public string Hash { get; private set; }
        public Block(DateTime timeStamp, Content content,int index, string previousHash = "")
        {
            _timeStamp = timeStamp;
            _nonce = 0;
            Content = content;
            PreviousHash = previousHash;
            Index = index;
            Hash = CreateHash();
        }
        public void MineBlock(int proofOfWorkDifficulty)
        {
            string hashValidationTemplate = new String('0', proofOfWorkDifficulty);

            while (Hash.Substring(0, proofOfWorkDifficulty) != hashValidationTemplate)
            {
                _nonce++;
                Hash = CreateHash();
            }
            Console.WriteLine("HASH={0} NOUCE={1}", Hash, _nonce);
        }
        public string CreateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = PreviousHash + _timeStamp + Content.Conteudo + _nonce;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower(); ;
            }
        }

    }
}
