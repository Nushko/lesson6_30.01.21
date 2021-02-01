using System;

namespace lesson6_30._01._21
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создайте DocumentWorker.
            DocumentWorker ver = new DocumentWorker();
            Console.Write("Введите ключ доступа: ");
            string key = Console.ReadLine();
            if (key == "pro")
            {
                ver = new ProDocumentWorker();
            }
            else if (key == "exp")
            {
                ver = new ExpertDocumentWorker();
            }

            ver.OpenDocument();
            ver.EditDocument();
            ver.SaveDocument();
            Console.ReadKey();

            //Создайте Player.
            Console.WriteLine();
            IPlayable play = new Player();
            play.Play();
            play.Pause();
            play.Stop();

            IRecordable rec = new Player();
            rec.Record();
            rec.Pause();
            rec.Stop();
        }
    }

    class DocumentWorker
    {
        public virtual void OpenDocument() =>
            Console.WriteLine("Документ открыт");

        public virtual void EditDocument() =>
            Console.WriteLine("" +
                "Редактирование документа доступно в версии Про");

        public virtual void SaveDocument() =>
            Console.WriteLine("Сохранение документа доступно в версии Про");
    }
    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument() =>
            Console.WriteLine("" +
                "Документ отредактирован");

        public override void SaveDocument() =>
            Console.WriteLine("" +
                "Документ сохранен в старом формате, сохранение в остальных " +
                "форматах доступно в версии Эксперт");
    }
    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument() =>
            Console.WriteLine("Документ сохранен в новом формате");
    }

    class Player : IPlayable, IRecordable
    {
        void IPlayable.Play() =>
            Console.WriteLine("Audio playing started");
        void IPlayable.Pause() =>
            Console.WriteLine("Audio playing paused");
        void IPlayable.Stop() =>
            Console.WriteLine("Audio playing stopped");
        void IRecordable.Record() =>
            Console.WriteLine("Audio recording started");
        void IRecordable.Pause() =>
            Console.WriteLine("Audio recording paused");
        void IRecordable.Stop() =>
            Console.WriteLine("Audio recording stopped");
    }
    public interface IPlayable
    {
        public void Play();
        public void Pause();
        public void Stop();
    }
    public interface IRecordable
    {
        public void Record();
        public void Pause();
        public void Stop();
    }
}