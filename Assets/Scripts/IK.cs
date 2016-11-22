using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IK : MonoBehaviour {
    
    public IKConstraint[] constraints;
    [Range(1, 100)]
    public int maxIterationNum;


    void Update()
    {
        SolveCCD(constraints, maxIterationNum);
    }


    public static void SolveCCD(IKConstraint[] constraints, int numIterations)
    {
        for (int i = 0; i < numIterations; i++)
        {
            foreach (IKConstraint constraint in constraints)
            {
                for (Transform joint = constraint.Effector.parent; joint != null; joint = joint.parent)
                {
                    Vector3 effectorDir = joint.InverseTransformPoint(constraint.Effector.position).normalized;
                    Vector3 targetDir = joint.InverseTransformPoint(constraint.Target.position).normalized;
                    float dot = Vector3.Dot(effectorDir, targetDir);
                    if ( dot< 1 - float.Epsilon)//except parallelism
                    {
                        float rotRad = Mathf.Acos(dot);
                        joint.Rotate(Vector3.Cross(effectorDir, targetDir), rotRad);
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class IKConstraint
{
    public Transform Effector;
    public Transform Target;
    public IKConstraint(Transform effector, Transform target)
    {
        Effector = effector;
        Target = target;
    }
}
