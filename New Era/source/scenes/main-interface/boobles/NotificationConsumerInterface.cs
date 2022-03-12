using Godot;
using Godot.Collections;
using System;
using System.Linq;

using Entities.Interface;

public interface NotificationConsumerInterface
{
    void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1);
    void DoEndMechanic(object obj);

    void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);
    void DoEndMechanicLogic();

    bool NotificationAlreadyExist(MainInterface main);
}
