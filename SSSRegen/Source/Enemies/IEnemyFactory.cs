﻿namespace SSSRegen.Source.Enemies
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy1();
        Enemy CreateEnemy2();
        Enemy CreateEnemy3();
        //ToDo Create more enemy types
    }
}