using Classes;
const string user1Address = "A";
const string user2Address = "B";
BlockChain blockChain = new BlockChain(proofOfWorkDifficulty: 5);
blockChain.CreateTransaction(new Content(user1Address, user2Address, 10000));
blockChain.CreateTransaction(new Content(user1Address, user2Address, 10000));
blockChain.CreateTransaction(new Content(user1Address, user2Address, 10000));
blockChain.CreateTransaction(new Content(user1Address, user2Address, 10000));
blockChain.CreateTransaction(new Content(user1Address, user2Address, 10000));
blockChain.CreateTransaction(new Content(user1Address, user2Address, 10000));
blockChain.CreateTransaction(new Content(user1Address, user2Address, 10000));
blockChain.CreateTransaction(new Content(user1Address, user2Address, 10000));
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.WriteLine();
Console.WriteLine("--------- Start mining ---------");
blockChain.MineBlock();
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.WriteLine("A user value: {0}", blockChain.GetBalance(user1Address));
Console.WriteLine();

blockChain.CreateTransaction(new Content(user2Address, user1Address, 10000));
blockChain.CreateTransaction(new Content(user2Address, user1Address, 10000));
blockChain.CreateTransaction(new Content(user2Address, user1Address, 10000));
blockChain.CreateTransaction(new Content(user2Address, user1Address, 10000));
blockChain.CreateTransaction(new Content(user2Address, user1Address, 10000));
blockChain.CreateTransaction(new Content(user2Address, user1Address, 10000));
blockChain.CreateTransaction(new Content(user2Address, user1Address, 10000));
blockChain.CreateTransaction(new Content(user2Address, user1Address, 10000));
Console.WriteLine("--------- Start mining ---------");
blockChain.MineBlock();
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.WriteLine("A user value: {0}", blockChain.GetBalance(user1Address));
Console.WriteLine();
PrintChain(blockChain);
Console.WriteLine();
/*Console.WriteLine("Hacking the blockchain...");
blockChain.Chain[1].Content = new List<Content> { new Content(user1Address, user2Address, 150) };
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());*/
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
        Console.WriteLine("MerkleRoot: {0}", block.MerkleRoot);
        Console.WriteLine("Nonce: {0}", block._nonce);
        //Console.WriteLine("Content: {0}", block.Content);
        Console.WriteLine("------ End Block ------");
    }
    Console.WriteLine("----------------- End Blockchain -----------------");
}