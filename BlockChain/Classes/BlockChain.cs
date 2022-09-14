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
        private List<Content> _pendingTransactions;
        public List<Block> Chain { get; set; }
        public BlockChain(int proofOfWorkDifficulty)
        {
            _proofOfWorkDifficulty = proofOfWorkDifficulty;
            _pendingTransactions = new List<Content>();
            Chain = new List<Block> { CreateGenesisBlock() };
        }
        public void CreateTransaction(Content transaction)
        {
            _pendingTransactions.Add(transaction);
        }
        public void MineBlock()
        {
            Block block = new Block(DateTime.Now, _pendingTransactions, Chain.Count() - 1, Chain.Last().Hash);
            block.MineBlock(_proofOfWorkDifficulty);
            Chain.Add(block);
            Chain.Last().MineBlock(_proofOfWorkDifficulty);

            _pendingTransactions = new List<Content>();
        }
        public bool IsValidChain()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];
                string HashTeste = currentBlock.CreateHash();
                if(currentBlock.Hash != HashTeste){
                    return false;
                }
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }
        public double GetBalance(string address)
        {
            double balance = 0;
            foreach (Block block in Chain)
            {
                foreach (Content transaction in block.Content)
                {
                    if (transaction.From == address)
                    {
                        balance -= transaction.Amount;
                    }
                    if (transaction.To == address)
                    {
                        balance += transaction.Amount;
                    }
                }
            }
            return balance;
        }
        private Block CreateGenesisBlock()
        {
            List<Content> transaction =new List<Content> { new Content("", "", 0) };
            return new Block(DateTime.Now, transaction,0, "0");
        }
    }
}
