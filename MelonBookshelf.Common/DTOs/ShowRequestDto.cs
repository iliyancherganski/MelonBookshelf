using MelonBookshelf.Data.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace MelonBookshelf.Models.Requests
{
    public class ShowRequestDto
    {
        public ShowRequestDto(ResourceRequest rr, IEnumerable<string> usersUpvoted)
        {
            Id = rr.Id;
            Type = rr.Type.ToString();
            Categories = rr.CategoryRequests.Select(x => x.Category.CategoryName);
            Title = rr.Title;
            Author = rr.Author;
            Description = rr.Description;
            Status = rr.Status.ToString();
            Priority = rr.Priority.ToString();
            DateAdded = rr.DateAdded;
            UsersUpvoted = usersUpvoted;
            Upvotes = UsersUpvoted.Count();
        }

        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public IEnumerable<string> Categories { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public string Priority { get; set; } = null!;

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public IEnumerable<string> UsersUpvoted { get; set; }

        [Required]
        public int Upvotes { get; set; }
    }
}

//      Статус на желанието – Очаква потвърждение, Подготвя се, Доставя се,
//      Доставена, Отхвърлена
//      ▪ Категория
//      ▪ Автор
//      ▪ Заглавие
//      ▪ Приоритет
//      ▪ Дата на добавяне
//▪ Брой потребители, подкрепили желанието
//• Да има възможност за преглед на потребителите, подкрепили
//желанието
//• Ако ресурсът не е на потребителя да има бутон „Подкрепи“ (Upvote)
//▪ Бутон за промяна на записа
//▪ Бутон за изтриване на желанието