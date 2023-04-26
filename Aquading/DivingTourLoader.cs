class DivingTourLoader
{
    private string _directoryPath;

    public DivingTourLoader(string directoryPath)
    {
        _directoryPath = directoryPath;
    }
    public void CreateFiles()
    {
        string tourFilePath1 = Path.Combine(_directoryPath, "1.txt");
        File.WriteAllText(tourFilePath1, "Тур 1\nВеликий Бар'єрний риф\n5\n500\n");
        string tourFilePath2 = Path.Combine(_directoryPath, "2.txt");
        File.WriteAllText(tourFilePath2, "Тур 2\nМальдіви\n5\n500\n");
        string tourFilePath3 = Path.Combine(_directoryPath, "3.txt");
        File.WriteAllText(tourFilePath3, "Тур 3\nЯпонія\n5\n500\n");

    }

    public List<DivingTour> LoadTours()
    {
        List<DivingTour> tours = new List<DivingTour>();

        foreach (string filePath in Directory.GetFiles(_directoryPath, "*.txt"))
        {
            string[] lines = File.ReadAllLines(filePath);

            DivingTour tour = new DivingTour();
            tour.Name = lines[0];
            tour.Location = lines[1];
            tour.Duration = int.Parse(lines[2]);
            tour.Price = decimal.Parse(lines[3]);

            tours.Add(tour);
        }

        return tours;
    }
   
}