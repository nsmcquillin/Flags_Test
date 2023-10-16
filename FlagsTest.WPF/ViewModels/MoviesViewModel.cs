using FlagsTest.LIBRARY.APIHelpers;
using FlagsTest.LIBRARY.Models.Movies;
using FlagsTest.WPF.Commands.Movies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlagsTest.WPF.ViewModels
{
    public class MoviesViewModel : ViewModelBase
    {
        public MoviesViewModel(MainWindowViewModel vmMainWindow)
        {
            MainWindowVM = vmMainWindow;
            _title = "Movie Search";
            HasNoItems = true;
            HasItems = false;
            //ShowMovieDetails = true;
            //ShowCastDetails = false;
            SearchMoviesCommand = new SearchMovieCommand(this);
            ShowCastDetailsCommand = new ShowCastDetailsCommand(this);

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

        private bool _hasItems;
        public bool HasItems
        {
            get { return _hasItems; }
            set
            {
                _hasItems = value;
                NotifyPropertyChanged();
            }
        }

        private bool _hasNoItems;
        public bool HasNoItems
        {
            get { return _hasNoItems; }
            set
            {
                _hasNoItems = value;
                NotifyPropertyChanged();
            }
        }

        //private bool _showMovieDetails;
        //public bool ShowMovieDetails
        //{
        //    get { return _showMovieDetails; }
        //    set
        //    {
        //        _showMovieDetails = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //private bool _showCastDetails;
        //public bool ShowCastDetails
        //{
        //    get { return _showCastDetails; }
        //    set
        //    {
        //        _showCastDetails = value;
        //        NotifyPropertyChanged();
        //    }
        //}

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

        private List<Movie> _movieList;
        public List<Movie> MovieList
        {
            get { return _movieList; }
            set
            {
                _movieList = value;
                NotifyPropertyChanged();
                if (MovieList != null)
                {
                    if (MovieList.Count > 0)
                    {
                        HasItems = true;
                        HasNoItems = false;
                        
                    }
                    else
                    {
                        HasItems = false;
                        HasNoItems = true;
                        
                    }
                }
            }
        }

        private Movie _selectedMovie;
        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                NotifyPropertyChanged();


            }
        }

        private string _selectedMovieId;
        public string SelectedMovieId
        {
            get { return _selectedMovieId; }
            set
            {
                _selectedMovieId = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SearchMoviesCommand { get; }

        public ICommand ShowCastDetailsCommand { get; }

        public ICommand CloseCastDetailsCommand { get; }


    }
}
