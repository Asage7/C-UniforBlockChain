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
        public List<Content> Content { get; set; }
        public string Hash { get; private set; }
        public string MerkleRoot { get; private set; }
        public Block(DateTime timeStamp, List<Content> content,int index, string previousHash = "")
        {
            _timeStamp = timeStamp;
            _nonce = 0;
            Content = content;
            PreviousHash = previousHash;
            Index = index;
            List<string> MerkleList = new List<string>();
            foreach (var con in Content)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    string Data = con.Amount.ToString();
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Data));
                    MerkleList.Add(BitConverter.ToString(bytes).Replace("-", "").ToLower());
                }
            }
            MerkleRoot = CreateMerkleRoot(MerkleList);
            Hash = CreateHash();
        }
        public string CreateMerkleRoot(IList<string> leaves)
        {
            if (leaves == null || !leaves.Any())
                return string.Empty;
            if (leaves.Count() == 1)
                return leaves.First();
                
            
            if (leaves.Count() % 2 > 0)
                leaves.Add(leaves.Last());

            List<string> branches = new List<string>();

            for(int i = 0; i<leaves.Count(); i += 2)
            {
                var leafPair = string.Concat(leaves[i], leaves[i + 1]);
                using (SHA256 sha256 = SHA256.Create())
                {
                    string Data = leafPair;
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Data));
                    branches.Add(BitConverter.ToString(bytes).Replace("-", "").ToLower());
                }
            }
            return CreateMerkleRoot(branches);
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
                string rawData = PreviousHash + _timeStamp + MerkleRoot + _nonce;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower(); ;
            }
        }

    }
}
