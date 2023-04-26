class EquipmentLoader
{
    private string _directoryPath;

    public EquipmentLoader(string directoryPath)
    {
        _directoryPath = directoryPath;
    }
    public void CreateFiles()
    {
        string tourFilePath1 = Path.Combine(_directoryPath, "1.txt");
        File.WriteAllText(tourFilePath1, "Звичайне спорядження\nУкраїна\n100\n");
        string tourFilePath2 = Path.Combine(_directoryPath, "2.txt");
        File.WriteAllText(tourFilePath2, "Просунуте спорядження\nСША\n250\n");
        string tourFilePath3 = Path.Combine(_directoryPath, "3.txt");
        File.WriteAllText(tourFilePath3, "Професійне спорядження\nЯпонія\n500\n");

    }
    public List<Equipment> LoadEquipment()
    {
        List<Equipment> equipments = new List<Equipment>();

        foreach (string filePath in Directory.GetFiles(_directoryPath, "*.txt"))
        {
            string[] lines = File.ReadAllLines(filePath);

            Equipment equipment = new Equipment();
            equipment.Name = lines[0];
            equipment.Manufacturer = lines[1];
            equipment.Price = decimal.Parse(lines[2]);

            equipments.Add(equipment);
        }

        return equipments;
    }
}