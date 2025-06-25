using System.Collections.Generic;

public class CubeBuilder
{
    public void BuildCubes(Cube parentCube, List<Cube> cubes)
    {
        bool hasSplitter = parentCube.TryGetComponent(out Splitter splitter);

        foreach (Cube spawnCube in cubes)
        {
            Reduce(spawnCube);
            ChangeColor(spawnCube);

            if (hasSplitter)
            {
                SetNewDivideChance(spawnCube, splitter.CurrentSplitProbability);
            }
        }
    }
    
    private void Reduce(Cube cube)
    {
        bool hasReducer = cube.TryGetComponent(out Reducer reducer);

        if (hasReducer) 
            reducer.ReduceScale();
    }
        
    private void ChangeColor(Cube cube)
    {
        bool hasColorChanger = cube.TryGetComponent(out ColorChanger colorChanger);

        if (hasColorChanger) 
            colorChanger.GenerateRandomColor();
    }

    private void SetNewDivideChance(Cube cube, float divideChance)
    {
        bool hasChanceDivider = cube.TryGetComponent(out Splitter splitter);

        if (hasChanceDivider) 
            splitter.SetReducedSplitProbability(divideChance);
    }
}