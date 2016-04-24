﻿namespace AvalonStudio.MVVM
{
    using Extensibility;
    using ReactiveUI;
    using System.ComponentModel.Composition;

    [InheritedExport(typeof(ToolViewModel))]
    public abstract class ToolViewModel : ToolViewModel<object>
    {
        public ToolViewModel() : base(null)
        {
            //var shell = AvalonStudio.Extensibility.Shell.Instance.MainShell;
        }

        
        public virtual IShell Shell { get; set; }

    }    


    public abstract class ToolViewModel<T> :ViewModel<T>
    {
        public ToolViewModel(T model) : base (model)
        {

        }

        // TODO This should use ToolControl
        private string title;
        public string Title
        {
            get { return title; }
            set { this.RaiseAndSetIfChanged(ref title, value); }
        }
    }

    public abstract class ViewModel : ViewModel<object>
    {
        public ViewModel() : base(null)
        {

        }        
    }

    public abstract class ViewModel<T> : ReactiveObject
    {
        public ViewModel(T model)
        {
            this.model = model;
        }

        private T model;
        public T Model
        {
            get { return model; }
            set { this.RaiseAndSetIfChanged(ref model, value); }
        }

        public void Invalidate ()
        {
            this.RaisePropertyChanged("");
        }
    }
}
