 class Interface
{
	public void Run()
	{
        Console.OutputEncoding = System.Text.Encoding.Default;

        DivingTourLoader loader = new DivingTourLoader(@"D:\Diving\DivingTours");
        EquipmentLoader eloader = new EquipmentLoader(@"D:\Diving\Equipment");
        loader.CreateFiles();
        eloader.CreateFiles();
        List<DivingTour> tours = loader.LoadTours();
        List<Equipment> equipments = eloader.LoadEquipment();

    m1:
        Console.WriteLine("Доступні тури:");
        Console.WriteLine();

        for (int i = 0; i < tours.Count; i++)
        {
            DivingTour tour = tours[i];

            Console.WriteLine($"{i + 1}. {tour.Name} - {tour.Location} ({tour.Duration} днів) - {tour.Price}$");
        }

        Console.WriteLine();
        Console.Write("Введіть номер туру, який ви бажаєте замовити: ");
        

        int tourNumber = int.Parse(Console.ReadLine());
        if (tourNumber != 1 && tourNumber !=2 && tourNumber != 3)
        {
            Console.WriteLine();
            Console.WriteLine("Ви ввели неправильний номер туру, спробуйте ще раз");
            Console.WriteLine();
            goto m1;
        }
        DivingTour selectedTour = tours[tourNumber - 1];

        Console.WriteLine();
        Console.WriteLine($"Ви обрали {selectedTour.Name} тур в {selectedTour.Location} тур буде проходити {selectedTour.Duration} днів.");
        m2:
        Console.WriteLine("Доступне спорядження:");
        Console.WriteLine();

        for (int i = 0; i < equipments.Count; i++)
        {
            Equipment equipment = equipments[i];

            Console.WriteLine($"{i + 1}. {equipment.Name} - {equipment.Manufacturer} {equipment.Price}$");
        }

        Console.WriteLine();
        Console.Write("Введіть номер спорядження, яке ви бажаєте замовити: ");

        int equipmentNumber = int.Parse(Console.ReadLine());
        if (equipmentNumber != 1 && equipmentNumber != 2 && equipmentNumber != 3)
        {
            Console.WriteLine();
            Console.WriteLine("Ви ввели неправильний номер спорядження, спробуйте ще раз");
            Console.WriteLine();
            goto m2;
        }

        Equipment selectedEquipment = equipments[equipmentNumber - 1];
        m3:
        Console.WriteLine();
        Console.WriteLine($"Ви обрали {selectedEquipment.Name} , виробник: {selectedEquipment.Manufacturer}");


        decimal sum = selectedTour.Price + selectedEquipment.Price;
        Console.WriteLine($"Загальна сума тура: {sum}$.");
        Console.WriteLine();
        Console.WriteLine("Щоб повернутися до вибору, натисніть 1");
        Console.WriteLine("Щоб підтвердити вибір, натисніть 2");
        int check = Convert.ToInt32(Console.ReadLine());
        if (check != 1 && check != 2)
        {
            Console.WriteLine();
            Console.WriteLine("Ви ввели неправильний номер, спробуйте ще раз");
            Console.WriteLine();
            goto m3;
        }else if(check == 1)
        {
            goto m1;
        }
        Console.WriteLine("Введіть шлях до файлу, куди потрібно зберегти обраний тур (або натисніть Enter, щоб використати стандартний шлях): ");
        string inputPath = Console.ReadLine();
        string filePath = string.IsNullOrEmpty(inputPath) ? @"D:\MyTour\tour.txt" : inputPath;

        SaveSelectedTourToFile(selectedTour, selectedEquipment, filePath);
        Console.WriteLine($"Обранний тур був збережений:  {filePath}.");
    }
    static void SaveSelectedTourToFile(DivingTour selectedTour, Equipment selectedEquipment, string filePath)
    {
        string[] lines = new string[]
        {
        selectedTour.Name,
        selectedTour.Location,
        selectedTour.Duration.ToString(),
        selectedTour.Price.ToString(),
        selectedEquipment.Name,
        selectedEquipment.Manufacturer,
        selectedEquipment.Price.ToString()
        };

        string directoryPath = Path.GetDirectoryName(filePath);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.WriteAllLines(filePath, lines);
        
    }
}
