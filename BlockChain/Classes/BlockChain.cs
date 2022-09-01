using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BlockChain
    {
        private readonly int _proofOfWorkDifficulty;
        public List<Block> Chain { get; set; }
        public BlockChain(int proofOfWorkDifficulty)
        {
            _proofOfWorkDifficulty = proofOfWorkDifficulty;
            Chain = new List<Block> { CreateGenesisBlock() };
        }
        public void MineBlock(Content content)
        {
            Block block = new Block(DateTime.Now, content,Chain.Count()-1 );
            block.MineBlock(_proofOfWorkDifficulty);
            block.PreviousHash = Chain.Last().Hash;
            Chain.Add(block);
        }
        public bool IsValidChain()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];
                string HashTeste = currentBlock.CreateHash();
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }
        private Block CreateGenesisBlock()
        {
            Content transaction = new Content("Genesis");
            return new Block(DateTime.Now, transaction,0, "0");
        }
    }
}
