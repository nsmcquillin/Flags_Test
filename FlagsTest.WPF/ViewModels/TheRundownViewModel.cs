using FlagsTest.LIBRARY.Models.TheRundown;
using FlagsTest.WPF.Commands.Spoonacular;
using FlagsTest.WPF.Commands.TheRundown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlagsTest.WPF.ViewModels
{
    public class TheRundownViewModel : ViewModelBase
    {

        public TheRundownViewModel()
        {
            _title = "SPOONACULAR";
            SearchSportsCommand = new SearchSportsCommand(this);
            // GetRecipeCommand = new GetRecipeCommand(this);
        }

        private string _searchCriteria;
        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set
            {
                _searchCriteria = value;
                NotifyPropertyChanged();
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged();
            }
        }

        private List<Sport> _sportList;
        public List<Sport> SportList
        {
            get { return _sportList; }
            set
            {
                _sportList = value;
                NotifyPropertyChanged();
            }
        }

        private Sport _selectedSport;
        public Sport SelectedSport
        {
            get { return _selectedSport; }
            set
            {
                _selectedSport = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SearchSportsCommand { get; }

 

    }
}
