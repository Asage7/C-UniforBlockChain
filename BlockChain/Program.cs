using Classes;
BlockChain blockChain = new BlockChain(proofOfWorkDifficulty: 3);
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.WriteLine();
Console.WriteLine("--------- Start mining ---------");
blockChain.MineBlock(new Content("ola"));
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.WriteLine();
Console.WriteLine("--------- Start mining ---------");
blockChain.MineBlock(new Content("estou minerando"));
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.WriteLine();
PrintChain(blockChain);
Console.WriteLine();
Console.WriteLine("Hacking the blockchain...");
Block Hacked = new Block(DateTime.Now, new Content("Hacked"), 1, blockChain.Chain[1].PreviousHash);
Hacked.CreateHash();
blockChain.Chain[1] = Hacked;
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.ReadKey();
    
 static void PrintChain(BlockChain blockChain)
{
    Console.WriteLine("----------------- Start Blockchain -----------------");
    foreach (Block block in blockChain.Chain)
    {
        Console.WriteLine();
        Console.WriteLine("------ Start Block ------");
        Console.WriteLine("Hash: {0}", block.Hash);
        Console.WriteLine("Previous Hash: {0}", block.PreviousHash);
        Console.WriteLine("Nonce: {0}", block._nonce);
        Console.WriteLine("Content: {0}", block.Content.Conteudo);
        Console.WriteLine("------ End Block ------");
    }
    Console.WriteLine("----------------- End Blockchain -----------------");
}