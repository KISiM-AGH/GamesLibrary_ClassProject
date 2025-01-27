﻿using System.ComponentModel.DataAnnotations;

namespace GamesLibraryShared.Games;

public class GameUserRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public AvailablePlatforms Platform { get; set; }
}