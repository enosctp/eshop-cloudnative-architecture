﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopCloudNative.Architecture.Extensions;
public static class Fluent
{
    public static T If<T>(this T target, Func<T, bool> condition, Func<T, T> actionWhenTrue, Func<T, T> actionWhenFalse = null)
    {
        if (condition == null) throw new ArgumentNullException(nameof(condition));
        if (actionWhenTrue == null) throw new ArgumentNullException(nameof(actionWhenTrue));

        if (target == null)
            return target;

        bool conditionResult = condition(target);

        if (conditionResult)
            target = actionWhenTrue(target);
        else if (actionWhenFalse != null)
            target = actionWhenFalse(target);

        return target;
    }

    public static T If<T>(this T target, Func<T, bool> condition, Action<T> actionWhenTrue, Action<T> actionWhenFalse = null)
    {
        if (condition == null) throw new ArgumentNullException(nameof(condition));
        if (actionWhenTrue == null) throw new ArgumentNullException(nameof(actionWhenTrue));

        if (target == null)
            return target;

        bool conditionResult = condition(target);

        if (conditionResult)
            actionWhenTrue(target);
        else if (actionWhenFalse != null)
            actionWhenFalse(target);

        return target;
    }
}
