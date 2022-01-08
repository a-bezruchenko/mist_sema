using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers;

[ApiController]
[Route("add_test_data")]
public class TestDataController : ControllerBase
{
    private static readonly List<GraphicCard> graphicCards = new()
    {
        new GraphicCard
        {
            Consumed_power = 30.5,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/7b3937e717d6a52a8e3351a25ce3d070/37a9ddc6abd9161645d3b8a24d249a29fd4dc72aa13e9cd14452f3fb69cfe2d8.jpg.webp",
            Manufacturer = "NVidia, MSI",
            Name = "GeForce 210",
            Perfomance = 518,
            MemoryVolume = 1,
            Price = 4299
        },

        new GraphicCard
        {
            Consumed_power = 19,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/f509f0c095767953aed4bf0a4dffdcc3/34224c1f710f7c03db347630554ea42772b679e4a4d99a9bea061e873201a115.jpg.webp",
            Manufacturer = "NVidia, Palit",
            Name = "GeForce GT 710 Silent LP",
            Perfomance = 1796,
            MemoryVolume = 2,
            Price = 4699
        },

        new GraphicCard
        {
            Consumed_power = 20,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/cc2c0d37de5de49bd922489ec27f8b69/a613b6b31c710e38966c73ee20e2aabcbc79ac5a7121accec99c7c6a4e85a9c0.jpg.webp",
            Manufacturer = "NVidia, GIGABYTE",
            Name = "GeForce GT 1030 Low Profile D4 2G",
            Perfomance = 6200,
            MemoryVolume = 2,
            Price = 7999
        },
        new GraphicCard
        {
            Consumed_power = 50,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/9ba4511d5a2528167fe0e8152b90f7d3/46eef741c727bfc3f27b22de8d765b337d0c9b58e87c3501c89bb02f25061df0.jpg.webp",
            Manufacturer = "AMD, PowerColor",
            Name = "Radeon RX 550 Red Dragon LP",
            Perfomance = 6867,
            MemoryVolume = 4,
            Price = 16999
        },
        new GraphicCard
        {
            Consumed_power = 75,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/f3906e0269abb713f070f2935013fb7b/4f0fc7411956c1bff040b0899066495da6544a65fbe8fabfc6ab87cd1a192719.jpg.webp",
            Manufacturer = "NVidia, GIGABYTE",
            Name = "GeForce GTX 1650 Low Profile OC",
            Perfomance = 18738,
            MemoryVolume = 4,
            Price = 31999
        },
        new GraphicCard
        {
            Consumed_power = 132,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/9729e32460f28677e12c76f62b1256f4/4e83c4c06754b83de72a75c75598aa1810690d84345c32beaeac4d8b456a33da.jpg.webp",
            Manufacturer = "AMD, Sapphire",
            Name = "Radeon RX 6600 PULSE",
            Perfomance = 37186,
            MemoryVolume = 8,
            Price = 62999
        },
        new GraphicCard
        {
            Consumed_power = 380,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/795c8cf125fed725912555a034f87775/1f7a4ceb5f283e156cf2fd2ad0bb82166d1d5892a73d1d8fe91d6de58b632e01.png.webp",
            Manufacturer = "NVidia, MSI",
            Name = "GeForce RTX 3090 GAMING X TRIO",
            Perfomance = 92107,
            MemoryVolume = 24,
            Price = 309999
        },
        new GraphicCard
        {
            Consumed_power = 300,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/fc8f30f9c727cfda21e7613cf0bbbe12/d1002d09fca73c1e7d431240d25fc4c9e84f898ffdf3d517ba37ca45e0daa133.jpg.webp",
            Manufacturer = "AMD, ASUS",
            Name = "Radeon RX 6900 XT STRIX GAMING LC",
            Perfomance = 88123,
            MemoryVolume = 16,
            Price = 179999
        }
    };

    private static readonly List<PowerSupply> powerSupplies = new()
    {
        new PowerSupply
        {
            Consumed_power = 600,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/8149bdac0ed00ab8f3cdf9f4af591ccf/1682bfad75ac864aecf78df46d6ef1c9d22f8e8fcd9ab5eba8416e959795a5bb.jpg.webp",
            Manufacturer = "Winard",
            Name = "Super Power Winard 450WA",
            Efficiency = 0.75,
            Price = 1199
        },
        new PowerSupply
        {
            Consumed_power = 625,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/8ff6e47cef9cdfba5185ae23fea24a10/3c4bdb852d9c37c6eb5847b2b28c81296d8f053b5127cc6683c745fd63f71a0f.jpg.webp",
            Manufacturer = "AeroCool",
            Name = "ECO 500W",
            Efficiency = 0.8,
            Price = 1899
        },
        new PowerSupply
        {
            Consumed_power = 610,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/792b4e6e8abf3c67431bfb1b1645c5e8/a48e4125eb85ec2d3da89bc76ef62d3b50185218209466f2b11a4c224f0c99d3.jpg.webp",
            Manufacturer = "ZALMAN",
            Name = "GigaMax (GVII) 550W",
            Efficiency = 0.9,
            Price = 3999
        },
        new PowerSupply
        {
            Consumed_power = 1000,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/408742fa1cdebeb9ef2be600f15ad95e/270854f9fecda7043afb2ea4595161fde381a8071f87bdc3b18aad781c9b4658.jpg.webp",
            Manufacturer = "AeroCool",
            Name = "VX PLUS 800W",
            Efficiency = 0.8,
            Price = 3999
        },
    };

    private static readonly List<Processor> processors = new()
    {
        new Processor
        {
            Consumed_power = 190,
            ImageLink = "https://items.s1.citilink.ru/1593041_v01_b.jpg",
            Manufacturer = "Intel",
            Name = "Core i7 12700K",
            Perfomance = 19739,
            ProcessorSocketType = "LGA1700",
            Price = 37690
        },
        new Processor
        {
            Consumed_power = 25,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/3b288cc4ed033cf685055fed58347b69/5a1664d3ee70341a2f5d04f1dbf64331e1a0a534f9ab1ba029dc5c04ca374816.jpg.webp",
            Manufacturer = "AMD",
            Name = "Sempron 2650 BOX",
            Perfomance = 352,
            ProcessorSocketType = "AM1",
            Price = 770
        },
        new Processor
        {
            Consumed_power = 300,
            ImageLink = "https://items.s1.citilink.ru/1527909_v01_b.jpg",
            Manufacturer = "AMD",
            Name = "Ryzen Threadripper 3990X",
            Perfomance = 51401,
            ProcessorSocketType = "sTRX4",
            Price = 412520
        },
        new Processor
        {
            Consumed_power = 65,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/29718c0bfbd6ccfbda6c745d0d87ac81/339c7546b8579cd6c0b29ca000c658474f0a6da3576ee731c4599fae38d84567.jpg.webp",
            Manufacturer = "AMD",
            Name = "Ryzen 5 1600 BOX",
            Perfomance = 6755,
            ProcessorSocketType = "AM4",
            Price = 14999
        },
        new Processor
        {
            Consumed_power = 65,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/0046355bffa09d8e5a49467405a17ccf/ba5849b79da7699feabd79e490c80aef373f7e5760e9a54d182cb5dbbb2efc65.jpg.webp",
            Manufacturer = "AMD",
            Name = "Ryzen 5 5600G BOX",
            Perfomance = 12023,
            ProcessorSocketType = "AM4",
            Price = 25799
        },
        new Processor
        {
            Consumed_power = 65,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/6ff35132a68f41c4cfde729741f6c29a/4ea0e29bd3c301434ca703d5a18efbc0f9759c8bc9ef0f5b24ac0c63beecfb77.jpg.webp",
            Manufacturer = "Intel",
            Name = "Core i5-9400",
            Perfomance = 5706,
            ProcessorSocketType = "LGA 1151-v2",
            Price = 14799
        },
        new Processor
        {
            Consumed_power = 65,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/ada7270a91c0c4e856039565db33be1f/0430a61423bd4adfca2e688de234f30fa1e6b03d8757ca4ebd8b96a7812fd0fe.jpg.webp",
            Manufacturer = "Intel",
            Name = "Core i7-9700 OEM",
            Perfomance = 8224,
            ProcessorSocketType = "LGA 1151-v2",
            Price = 21699
        }
    };

    private static readonly List<Ram> rams = new()
    {
        new Ram
        {
            Consumed_power = 5,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/4beffe6d44555333768b81ac9609dd9c/2f793db0d8faebd9c29a716881d928d092cb4f1166cf08368c5b91e0a4e129d4.jpg.webp",
            Manufacturer = "Apacer",
            Name = "[EL.08G2V.GNH] 8 ГБ",
            GenerationName = "DDR4",
            Volume = 8,
            Price = 2550
        },
        new Ram
        {
            Consumed_power = 5,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/e64e98aa9ec8ae547a9d10da7db6c629/e32c45b05dd0ce82bde0d722f76100a8e48a4406738fa6a470f9071e9638801f.jpg.webp",
            Manufacturer = "Goodram",
            Name = "[GR2400D464L17S/8G] 8 ГБ",
            GenerationName = "DDR4",
            Volume = 8,
            Price = 2550
        },
        new Ram
        {
            Consumed_power = 5,
            ImageLink = "https://c.dns-shop.ru/thumb/st4/fit/300/300/7312e2bc699387ac8ec015e54502b04f/f93eea46dc5ca5c58810f355311eefafd5215ce9656e31933e0616b4d65bf651.jpg.webp",
            Manufacturer = "AMD",
            Name = "Radeon R5 Entertainment Series [R532G1601U1S-U] DDR3 2 ГБ",
            GenerationName = "DDR3",
            Volume = 2,
            Price = 999
        }
    };

    private static readonly List<StorageDevice> storageDevices = new()
    {
        new StorageDevice
        {
            Consumed_power = 10,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/7eedf3356a2e0c44c448a5e59bbe9c10/88653671c4d7c76f7762f0672da0ccd4312a4bb671d9b9c1b194cc3f9aed8fa5.jpg.webp",
            Manufacturer = "Smartbuy",
            Name = "120 ГБ 2.5\" SATA накопитель Smartbuy Revival 3[SB120GB - RVVL3 - 25SAT3]",
            StorageType = "SSD",
            Volume = 120,
            Price = 1399
        },
        new StorageDevice
        {
            Consumed_power = 10,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/2be22025f2d565a6bcbf3106c7163c3a/fa8194d6225faad41c864012b4428e1e432086f29dfa504c229f454cfd427913.jpg.webp",
            Manufacturer = "WD",
            Name = "500 ГБ Жесткий диск WD Blue [WD5000AZRZ]",
            StorageType = "HDD",
            Volume = 500,
            Price = 2599
        },
        new StorageDevice
        {
            Consumed_power = 10,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/372ceb5c7ffb255cd1c2a3182100e82e/388d249f2647a68a2a5281c68ff6df754843fcf3c433ba22ef257b228b715574.jpg.webp",
            Manufacturer = "Seagate",
            Name = "2 ТБ Жесткий диск Seagate BarraCuda [ST2000DM008]",
            StorageType = "HDD",
            Volume = 2000,
            Price = 4099
        }
    };

    private static readonly List<SystemBoard> systemBoards = new()
    {
        new SystemBoard
        {
            Consumed_power = 5,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/635e7b39dbeabde5c97c096e25587d8d/1e63841f75670d4fd978140be4c702bf449561f2a88e19a51fe72d6d20c36b59.jpg.webp",
            Manufacturer = "GIGABYTE",
            Name = "H310M S2",
            MemorySlotsCount = 2,
            MemoryGenerationName = "DDR4",
            SataPortsCount = 4,
            ProcessorSocketType = "LGA 1151-v2",
            Price = 3199
        },
        new SystemBoard
        {
            Consumed_power = 5,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/4704bf2a601abe7d0171405f896b86e5/ee726604f2aba57d1902e154e3b11d59d300834ba9f3d0aa113c21dc161e112c.jpg.webp",
            Manufacturer = "ASRock",
            Name = "A320M-DVS R4.0",
            MemorySlotsCount = 2,
            MemoryGenerationName = "DDR4",
            SataPortsCount = 4,
            ProcessorSocketType = "AM4",
            Price = 3399
        },
        new SystemBoard
        {
            Consumed_power = 5,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/9bbf55ee947d5cdb0f1a63076a7920e1/edd555a2a33c8e75652a3d67af4227d532ede6b5720bf11dca0b39c3103f8a61.jpg.webp",
            Manufacturer = "MSI",
            Name = "MAG B365M MORTAR",
            MemorySlotsCount = 4,
            MemoryGenerationName = "DDR4",
            SataPortsCount = 6,
            ProcessorSocketType = "LGA 1151-v2",
            Price = 6499
        },
        new SystemBoard
        {
            Consumed_power = 5,
            ImageLink = "https://c.dns-shop.ru/thumb/st1/fit/300/300/375c12d628b000eaf28834ef6a33f9e2/8a8eeb244564c4eec162b39c2df8b6ddf388c7583944479be2569d5f43e2f79e.jpg.webp",
            Manufacturer = "ASUS",
            Name = "PRIME A520M-A II",
            MemorySlotsCount = 4,
            MemoryGenerationName = "DDR4",
            SataPortsCount = 4,
            ProcessorSocketType = "AM4",
            Price = 6599
        },
    };

    private readonly IComponentRepository componentRepository;

    public TestDataController(IComponentRepository componentRepository)
    {
        this.componentRepository = componentRepository;
    }

    [HttpPost]
    public void AddDataToDb()
    {
        foreach (ComputerComponent c in graphicCards)
            componentRepository.Add(c);
        foreach (ComputerComponent c in powerSupplies)
            componentRepository.Add(c);
        foreach (ComputerComponent c in processors)
            componentRepository.Add(c);
        foreach (ComputerComponent c in rams)
            componentRepository.Add(c);
        foreach (ComputerComponent c in storageDevices)
            componentRepository.Add(c);
        foreach (ComputerComponent c in systemBoards)
            componentRepository.Add(c);
    }

    [HttpDelete]
    public void Clear()
    {
        foreach (ComputerComponent c in componentRepository.GetAll<GraphicCard>())
            componentRepository.Delete<GraphicCard>(c.Id);

        foreach (ComputerComponent c in componentRepository.GetAll<PowerSupply>())
            componentRepository.Delete<PowerSupply>(c.Id);

        foreach (ComputerComponent c in componentRepository.GetAll<Processor>())
            componentRepository.Delete<Processor>(c.Id);

        foreach (ComputerComponent c in componentRepository.GetAll<Ram>())
            componentRepository.Delete<Ram>(c.Id);

        foreach (ComputerComponent c in componentRepository.GetAll<StorageDevice>())
            componentRepository.Delete<StorageDevice>(c.Id);

        foreach (ComputerComponent c in componentRepository.GetAll<SystemBoard>())
            componentRepository.Delete<SystemBoard>(c.Id);
    }
}