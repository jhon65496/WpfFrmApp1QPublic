using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFrmApp1.Models;



namespace WpfFrmApp1.Data
{
    public class TestData
    {
        public TestData()
        {
            GenerateDataСalculationIndex();
            GenerateDataProviders();
            GenerateDataIndexProvider2();
        }


        private ObservableCollection<IndexCalculation> calculationIndexes;

        public ObservableCollection<IndexCalculation> СalculationIndexes
        {
            get { return calculationIndexes; }
            set { calculationIndexes = value; }
        }


        private ObservableCollection<Provider> providers;

        public ObservableCollection<Provider> Providers
        {
            get { return providers; }
            set { providers = value; }
        }


        private ObservableCollection<IndexProvider> indexProviders;

        public ObservableCollection<IndexProvider> IndexProviders
        {
            get { return indexProviders; }
            set { indexProviders = value; }
        }


        // ---- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        public void GenerateDataСalculationIndex()
        {
            var calculationIndexes = new ObservableCollection<IndexCalculation>();
            for (int i = 1; i < 11; i++)
            {
                var indexCalculation = new IndexCalculation()
                {
                    Id = i,
                    Name = $"NameIndex-{i}",
                    Description = $"DescriptionIndex-{i}"
                };
                calculationIndexes.Add(indexCalculation);
            }

            СalculationIndexes = calculationIndexes;
        }


        public void GenerateDataProviders()
        {
            Providers = new ObservableCollection<Provider>();
            for (int i = 1; i < 101; i++)
            {
                var provider = new Provider()
                {
                    Id = i,
                    Name = $"NameProvider-{i}",
                    Description = $"DescriptionProvider-{i}"
                };
                Providers.Add(provider);
            }
        }

        public void GenerateIndexProvider()
        {
            IndexProviders = new ObservableCollection<IndexProvider>();

            for (int i = 1; i < 11; i++)            // IndexProvider
            {
                for (int ii = 3; ii < 11; ii++)     // Index
                {

                    int indexCurrentProvider = 0;

                    int step = 10;
                    int indexFirstProvider = indexCurrentProvider + 1;
                    int indeLastsProvider = indexFirstProvider + step;

                    for (int ip = indexFirstProvider; ip < indeLastsProvider; ip++) // Provider
                    {
                        var indexProveder = new IndexProvider()
                        {
                            Id = i,
                            IdIndex = ii,
                            IdProvider = ip
                        };
                        IndexProviders.Add(indexProveder);
                    }
                }
            }
        }


        public void GenerateDataIndexProvider2()
        {
            IndexProviders = new ObservableCollection<IndexProvider>();
            
            int idIndexProvider = 1;
            int indexCurrentProvider = 1;

            for (int ii = 3; ii < 11; ii++)     // Index
            {
                int step = 10;
                int indexFirstProvider = indexCurrentProvider;
                int indeLastProvider = indexFirstProvider + step;

                for (int ip = indexFirstProvider; ip < indeLastProvider; ip++) // Provider
                {
                    // idIndexProvider            // IndexProvider

                    var indexProveder = new IndexProvider()
                    {
                        Id = idIndexProvider,
                        IdIndex = ii,
                        IdProvider = ip
                    };
                    IndexProviders.Add(indexProveder);
                    idIndexProvider++;
                }
                indexCurrentProvider = indeLastProvider++;
            }

        }
    }
}
