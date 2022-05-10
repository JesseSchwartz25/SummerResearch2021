using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOrientations : MonoBehaviour
{
    // Start is called before the first frame update


    //this is how every tower is built. 
    //position is first, then orientation
    //each trial consists of 6 blocks, each block has two values (x and z position or x/z and y rotation)

    public float[,] blocksPos = new float[300, 2];
    public int[,] orientation = new int[300, 2];
    void Start()
    {
        //x
        blocksPos[0, 0] = 0;
        //z
        blocksPos[0, 1] = 0;

        blocksPos[1, 0] = 0;
        blocksPos[1, 1] = 0;

        blocksPos[2, 0] = 0;
        blocksPos[2, 1] = 0;

        blocksPos[3, 0] = 0;
        blocksPos[3, 1] = 0;

        blocksPos[4, 0] = 0;
        blocksPos[4, 1] = 0;

        blocksPos[5, 0] = 0;
        blocksPos[5, 1] = 0;

        blocksPos[6, 0] = 0;
        blocksPos[6, 1] = -.4f;

        blocksPos[7, 0] = 0;
        blocksPos[7, 1] = 0;

        blocksPos[8, 0] = 0f;
        blocksPos[8, 1] = .4f;

        blocksPos[9, 0] = 0f;
        blocksPos[9, 1] = -.4f;

        blocksPos[10, 0] = 0;
        blocksPos[10, 1] = 0;

        blocksPos[11, 0] = 0f;
        blocksPos[11, 1] = 0.4f;

        blocksPos[12, 0] = 0;
        blocksPos[12, 1] = 0;

        blocksPos[13, 0] = 0;
        blocksPos[13, 1] = 0;

        blocksPos[14, 0] = .3f;
        blocksPos[14, 1] = 0f;

        blocksPos[15, 0] = .3f;
        blocksPos[15, 1] = 0f;

        blocksPos[16, 0] = .3f;
        blocksPos[16, 1] = 0f;

        blocksPos[17, 0] = .3f;
        blocksPos[17, 1] = 0f;
        //
        blocksPos[18, 0] = 0f;
        blocksPos[18, 1] = 0f;

        blocksPos[19, 0] =-.3f;
        blocksPos[19, 1] = 0f;

        blocksPos[20, 0] = .3f;
        blocksPos[20, 1] = 0f;

        blocksPos[21, 0] = 0f;
        blocksPos[21, 1] = 0f;

        blocksPos[22, 0] =-.3f;
        blocksPos[22, 1] = 0f;

        blocksPos[23, 0] =-.3f;
        blocksPos[23, 1] = 0f;
        //
        blocksPos[24, 0] = .2f;
        blocksPos[24, 1] = .4f;

        blocksPos[25, 0] =-.3f;
        blocksPos[25, 1] = .3f;

        blocksPos[26, 0] =-.1f;
        blocksPos[26, 1] = 0f;

        blocksPos[27, 0] = .4f;
        blocksPos[27, 1] = .04f;

        blocksPos[28, 0] =-.2f;
        blocksPos[28, 1] = 0f;

        blocksPos[29, 0] = 0f;
        blocksPos[29, 1] = .1f;
        //
        blocksPos[30, 0] = 0;
        blocksPos[30, 1] = 0;

        blocksPos[31, 0] = 0;
        blocksPos[31, 1] = 0.4f;

        blocksPos[32, 0] = 0f;
        blocksPos[32, 1] = .4f;

        blocksPos[33, 0] = 0f;
        blocksPos[33, 1] = .3f;

        blocksPos[34, 0] = 0f;
        blocksPos[34, 1] = 0f;

        blocksPos[35, 0] = 0f;
        blocksPos[35, 1] = .3f;
        //
        blocksPos[36, 0] = .4f;
        blocksPos[36, 1] = 0f;

        blocksPos[37, 0] = 0f;
        blocksPos[37, 1] = 0f;

        blocksPos[38, 0] = 0f;
        blocksPos[38, 1] = 0f;

        blocksPos[39, 0] = 0f;
        blocksPos[39, 1] = 0f;

        blocksPos[40, 0] = 0f;
        blocksPos[40, 1] = 0f;

        blocksPos[41, 0] = .40f;
        blocksPos[41, 1] = 0f;
        //
        blocksPos[42, 0] = 0f;
        blocksPos[42, 1] = .20f;

        blocksPos[43, 0] = .30f;
        blocksPos[43, 1] = .10f;

        blocksPos[44, 0] =-.20f;
        blocksPos[44, 1] = .30f;

        blocksPos[45, 0] =-.20f;
        blocksPos[45, 1] = 0f;

        blocksPos[46, 0] =-.10f;
        blocksPos[46, 1] = .30f;

        blocksPos[47, 0] = -.10f;
        blocksPos[47, 1] =-.30f;
        //
        blocksPos[48, 0] =-.30f;
        blocksPos[48, 1] = -.20f;

        blocksPos[49, 0] = .30f;
        blocksPos[49, 1] = -.10f;

        blocksPos[50, 0] = .20f;
        blocksPos[50, 1] = 0f;

        blocksPos[51, 0] =-.20f;
        blocksPos[51, 1] = .10f;

        blocksPos[52, 0] =-.10f;
        blocksPos[52, 1] = 0f;

        blocksPos[53, 0] =-.30f;
        blocksPos[53, 1] = .20f;
        //
        blocksPos[54, 0] =-.30f;
        blocksPos[54, 1] =-.20f;

        blocksPos[55, 0] = .30f;
        blocksPos[55, 1] = .10f;

        blocksPos[56, 0] =-.30f;
        blocksPos[56, 1] = .20f;

        blocksPos[57, 0] = 0f;
        blocksPos[57, 1] = 0f;

        blocksPos[58, 0] = .40f;
        blocksPos[58, 1] = 00f;

        blocksPos[59, 0] = .40f;
        blocksPos[59, 1] = 0f;
        //
        blocksPos[60, 0] =-.30f;
        blocksPos[60, 1] =-.30f;

        blocksPos[61, 0] =-.10f;
        blocksPos[61, 1] =-.10f;

        blocksPos[62, 0] = 0f;
        blocksPos[62, 1] = 0f;

        blocksPos[63, 0] = .10f;
        blocksPos[63, 1] = .10f;

        blocksPos[64, 0] = .30f;
        blocksPos[64, 1] = .30f;

        blocksPos[65, 0] = 0f;
        blocksPos[65, 1] = 0f;
        //
        blocksPos[66, 0] = 0f;
        blocksPos[66, 1] = 0f;
        
        blocksPos[67, 0] = 0f;
        blocksPos[67, 1] = 0f;

        blocksPos[68, 0] = 0f;
        blocksPos[68, 1] = 0f;

        blocksPos[69, 0] = 0f;
        blocksPos[69, 1] = .20f;

        blocksPos[70, 0] = .20f;
        blocksPos[70, 1] = .20f;

        blocksPos[71, 0] =-.20f;
        blocksPos[71, 1] = 00f;
        //
        blocksPos[72, 0] = 00f;
        blocksPos[72, 1] = 0f;

        blocksPos[73, 0] =-0f;
        blocksPos[73, 1] = -.10f;

        blocksPos[74, 0] = 0f;
        blocksPos[74, 1] =-.150f;

        blocksPos[75, 0] = 00f;
        blocksPos[75, 1] =-.20f;

        blocksPos[76, 0] = 0f;
        blocksPos[76, 1] =-.250f;

        blocksPos[77, 0] = 00f;
        blocksPos[77, 1] =-.30f;
        //
        blocksPos[78, 0] =-.10f;
        blocksPos[78, 1] =-30f;

        blocksPos[79, 0] =-.20f;
        blocksPos[79, 1] = 0f;

        blocksPos[80, 0] = .10f;
        blocksPos[80, 1] =-.20f;

        blocksPos[81, 0] = 0f;
        blocksPos[81, 1] = .30f;

        blocksPos[82, 0] = .10f;
        blocksPos[82, 1] =-.30f;

        blocksPos[83, 0] = .20f;
        blocksPos[83, 1] = 0f;
        //
        blocksPos[84, 0] = 0f;
        blocksPos[84, 1] =-.30f;

        blocksPos[85, 0] = 00f;
        blocksPos[85, 1] = 0f;

        blocksPos[86, 0] = 0f;
        blocksPos[86, 1] = .30f;

        blocksPos[87, 0] = .30f;
        blocksPos[87, 1] = 0f;

        blocksPos[88, 0] = 0f;
        blocksPos[88, 1] = 0f;

        blocksPos[89, 0] =-.30f;
        blocksPos[89, 1] = 0f;
        //
        blocksPos[90, 0] = .10f;
        blocksPos[90, 1] = 0f;

        blocksPos[91, 0] = .10f;
        blocksPos[91, 1] =-.30f;

        blocksPos[92, 0] = 0f;
        blocksPos[92, 1] =-.20f;

        blocksPos[93, 0] = .40f;
        blocksPos[93, 1] = .20f;

        blocksPos[94, 0] =-.30f;
        blocksPos[94, 1] = .20f;

        blocksPos[95, 0] = 0f;
        blocksPos[95, 1] = .30f;
        //
        blocksPos[96, 0] = 0f;
        blocksPos[96, 1] = 0f;

        blocksPos[97, 0] = .10f;
        blocksPos[97, 1] = .10f;

        blocksPos[98, 0] = .150f;
        blocksPos[98, 1] = .150f;

        blocksPos[99, 0] = .20f;
        blocksPos[99, 1] = .20f;

        blocksPos[100, 0] = .30f;
        blocksPos[100, 1] = 00f;

        blocksPos[101, 0] =-.30f;
        blocksPos[101, 1] = .30f;
        //
        blocksPos[102, 0] = 0f;
        blocksPos[102, 1] = 0f;

        blocksPos[103, 0] = .10f;
        blocksPos[103, 1] =-.20f;

        blocksPos[104, 0] = .20f;
        blocksPos[104, 1] =-.10f;

        blocksPos[105, 0] = .30f;
        blocksPos[105, 1] = 0f;

        blocksPos[106, 0] =-.40f;
        blocksPos[106, 1] = .10f;

        blocksPos[107, 0] =-.20f;
        blocksPos[107, 1] = 0f;
        //
        blocksPos[108, 0] = 0f;
        blocksPos[108, 1] =-.40f;

        blocksPos[109, 0] = 0f;
        blocksPos[109, 1] =-.20f;

        blocksPos[110, 0] = 0f;
        blocksPos[110, 1] =-.20f;

        blocksPos[111, 0] = .40f;
        blocksPos[111, 1] = -.40f;

        blocksPos[112, 0] = .40f;
        blocksPos[112, 1] = .20f;

        blocksPos[113, 0] = .40f;
        blocksPos[113, 1] = .20f;
        //
        blocksPos[114, 0] = 0f;
        blocksPos[114, 1] = 0f;

        blocksPos[115, 0] = .30f;
        blocksPos[115, 1] =-.20f;

        blocksPos[116, 0] = 0f;
        blocksPos[116, 1] = .40f;

        blocksPos[117, 0] =-.20f;
        blocksPos[117, 1] =-.30f;

        blocksPos[118, 0] = .30f;
        blocksPos[118, 1] = .10f;

        blocksPos[119, 0] =-.20f;
        blocksPos[119, 1] = 0f;
        //
        blocksPos[120, 0] = 0f;
        blocksPos[120, 1] = 0f;

        blocksPos[121, 0] = 0f;
        blocksPos[121, 1] = -.10f;

        blocksPos[122, 0] = .10f;
        blocksPos[122, 1] =-.10f;

        blocksPos[123, 0] = 0f;
        blocksPos[123, 1] = -.20f;

        blocksPos[124, 0] = .10f;
        blocksPos[124, 1] = -.250f;

        blocksPos[125, 0] = .1250f;
        blocksPos[125, 1] =-.30f;
        //
        blocksPos[126, 0] = .10f;
        blocksPos[126, 1] =-.10f;

        blocksPos[127, 0] = -.20f;
        blocksPos[127, 1] = 0f;

        blocksPos[128, 0] = 0f;
        blocksPos[128, 1] = 0f;

        blocksPos[129, 0] =-.30f;
        blocksPos[129, 1] = .10f;

        blocksPos[130, 0] =-.40f;
        blocksPos[130, 1] = 0f;

        blocksPos[131, 0] = .30f;
        blocksPos[131, 1] = 0f;
        //
        blocksPos[132, 0] = 0f;
        blocksPos[132, 1] = .10f;

        blocksPos[133, 0] = 0f;
        blocksPos[133, 1] =.10f;

        blocksPos[134, 0] =-.10f;
        blocksPos[134, 1] = .20f;

        blocksPos[135, 0] =-.10f;
        blocksPos[135, 1] = .20f;

        blocksPos[136, 0] = 0.0f;
        blocksPos[136, 1] = .30f;
        //
        blocksPos[137, 0] = .00f;
        blocksPos[137, 1] =-.10f;

        blocksPos[138, 0] = 0f;
        blocksPos[138, 1] = 0f;

        blocksPos[139, 0] = 0f;
        blocksPos[139, 1] = .30f;

        blocksPos[140, 0] = .20f;
        blocksPos[140, 1] =-.20f;

        blocksPos[141, 0] =-.20f;
        blocksPos[141, 1] = .30f;

        blocksPos[142, 0] = 0f;
        blocksPos[142, 1] = .10f;

        blocksPos[143, 0] =-.20f;
        blocksPos[143, 1] = 0f;

        blocksPos[144, 0] =-.30f;
        blocksPos[144, 1] = 0f;

        blocksPos[145, 0] =-.20f;
        blocksPos[145, 1] = 0f;

        blocksPos[146, 0] = .30f;
        blocksPos[146, 1] = .30f;

        blocksPos[147, 0] = 0f;
        blocksPos[147, 1] =-.20f;

        blocksPos[148, 0] =-.30f;
        blocksPos[148, 1] =-.10f;

        blocksPos[149, 0] = 0f;
        blocksPos[149, 1] =-.20f;

        blocksPos[150, 0] = .20f;
        blocksPos[150, 1] =-.10f;

        blocksPos[151, 0] = 0f;
        blocksPos[151, 1] = 0f;

        blocksPos[152, 0] = 0f;
        blocksPos[152, 1] = .20f;

        blocksPos[153, 0] = 0f;
        blocksPos[153, 1] =-.20f;

        blocksPos[154, 0] =-.20f;
        blocksPos[154, 1] = 0f;

        blocksPos[155, 0] = 0f;
        blocksPos[155, 1] = .30f;
        //
        blocksPos[156, 0] = 0f;
        blocksPos[156, 1] =-.10f;

        blocksPos[157, 0] =-.20f;
        blocksPos[157, 1] = 0f;

        blocksPos[158, 0] =-.30f;
        blocksPos[158, 1] =-.30f;

        blocksPos[159, 0] = .30f;
        blocksPos[159, 1] = .30f;

        blocksPos[160, 0] = .30f;
        blocksPos[160, 1] = .40f;

        blocksPos[161, 0] = .25f;
        blocksPos[161, 1] =.30f;
        //
        blocksPos[162, 0] = .10f;
        blocksPos[162, 1] = .10f;

        blocksPos[163, 0] =.120f;
        blocksPos[163, 1] = 0f;

        blocksPos[164, 0] = .120f;
        blocksPos[164, 1] =-.10f;

        blocksPos[165, 0] = .10f;
        blocksPos[165, 1] =-.20f;

        blocksPos[166, 0] = .10f;
        blocksPos[166, 1] = -.30f;

        blocksPos[167, 0] = .130f;
        blocksPos[167, 1] = -.30f;
        //
        blocksPos[168, 0] = 0f;
        blocksPos[168, 1] = 0f;

        blocksPos[169, 0] = .020f;
        blocksPos[169, 1] = -.040f;

        blocksPos[170, 0] = .20f;
        blocksPos[170, 1] =-.10f;

        blocksPos[171, 0] = .10f;
        blocksPos[171, 1] =-.120f;

        blocksPos[172, 0] = .120f;
        blocksPos[172, 1] = -.20f;

        blocksPos[173, 0] =.14f;
        blocksPos[173, 1] = -.2f;
        //
        blocksPos[174, 0] = .130f;
        blocksPos[174, 1] = 0f;

        blocksPos[175, 0] = .130f;
        blocksPos[175, 1] = -.10f;

        blocksPos[176, 0] =.14520f;
        blocksPos[176, 1] =-.20f;

        blocksPos[177, 0] =.15f;
        blocksPos[177, 1] =-.20f;

        blocksPos[178, 0] = .20f;
        blocksPos[178, 1] =-.20f;

        blocksPos[179, 0] = .220f;
        blocksPos[179, 1] = -.30f;
        //
        blocksPos[180, 0] =-.120f;
        blocksPos[180, 1] = .10f;

        blocksPos[181, 0] = -.350f;
        blocksPos[181, 1] = .10f;

        blocksPos[182, 0] = .20f;
        blocksPos[182, 1] =.10f;

        blocksPos[183, 0] = 0f;
        blocksPos[183, 1] = .10f;

        blocksPos[184, 0] = 0f;
        blocksPos[184, 1] =.10f;

        blocksPos[185, 0] = .20f;
        blocksPos[185, 1] = .10f;
        //
        blocksPos[186, 0] = -.20f;
        blocksPos[186, 1] = .10f;

        blocksPos[187, 0] =-.20f;
        blocksPos[187, 1] = .10f;

        blocksPos[188, 0] = -.250f;
        blocksPos[188, 1] = .10f;

        blocksPos[189, 0] = -.150f;
        blocksPos[189, 1] = .20f;

        blocksPos[190, 0] = -.1f;
        blocksPos[190, 1] = .30f;

        blocksPos[191, 0] =-.20f;
        blocksPos[191, 1] = 0f;
        //
        blocksPos[192, 0] =-.40f;
        blocksPos[192, 1] = 0f;

        blocksPos[193, 0] =-.40f;
        blocksPos[193, 1] = .20f;

        blocksPos[194, 0] =-.30f;
        blocksPos[194, 1] = 0f;

        blocksPos[195, 0] =-.20f;
        blocksPos[195, 1] = .20f;

        blocksPos[196, 0] =-.10f;
        blocksPos[196, 1] = 0f;

        blocksPos[197, 0] = 0f;
        blocksPos[197, 1] = 0f;

        blocksPos[198, 0] = 0f;
        blocksPos[198, 1] = 0f;

        blocksPos[199, 0] =-.10f;
        blocksPos[199, 1] = 0f;

        blocksPos[200, 0] = .30f;
        blocksPos[200, 1] = 0f;

        blocksPos[201, 0] =-.10f;
        blocksPos[201, 1] =-.1250f;

        blocksPos[202, 0] = .20f;
        blocksPos[202, 1] = .350f;

        blocksPos[203, 0] = 0f;
        blocksPos[203, 1] =-.10f;
        //
        blocksPos[204, 0] = .120f;
        blocksPos[204, 1] = 0f;

        blocksPos[205, 0] =-.120f;
        blocksPos[205, 1] = 0f;

        blocksPos[206, 0] = 0f;
        blocksPos[206, 1] = 0f;

        blocksPos[207, 0] = 0f;
        blocksPos[207, 1] =-.120f;

        blocksPos[208, 0] = 0f;
        blocksPos[208, 1] = .130f;

        blocksPos[209, 0] = .130f;
        blocksPos[209, 1] = 0f;
        //
        blocksPos[210, 0] =-.130f;
        blocksPos[210, 1] = .20f;

        blocksPos[211, 0] = 0f;
        blocksPos[211, 1] =-.20f;

        blocksPos[212, 0] = .10f;
        blocksPos[212, 1] = .40f;

        blocksPos[213, 0] =-.30f;
        blocksPos[213, 1] =-.20f;

        blocksPos[214, 0] = 0f;
        blocksPos[214, 1] = 0f;

        blocksPos[215, 0] = .20f;
        blocksPos[215, 1] =-.30f;

        blocksPos[216, 0] = 0f;
        blocksPos[216, 1] =-.30f;

        blocksPos[217, 0] = .20f;
        blocksPos[217, 1] = 0f;

        blocksPos[218, 0] =-.20f;
        blocksPos[218, 1] =-.10f;

        blocksPos[219, 0] = .30f;
        blocksPos[219, 1] = .20f;

        blocksPos[220, 0] = .40f;
        blocksPos[220, 1] = 0f;

        blocksPos[221, 0] = 0f;
        blocksPos[221, 1] =-.30f;
        //
        blocksPos[222, 0] = 0f;
        blocksPos[222, 1] = 0f;
        
        blocksPos[223, 0] = .020f;
        blocksPos[223, 1] = .120f;

        blocksPos[224, 0] = .0120f;
        blocksPos[224, 1] = .130f;

        blocksPos[225, 0] = .0230f;
        blocksPos[225, 1] = .20f;

        blocksPos[226, 0] = .0120f;
        blocksPos[226, 1] =.210f;

        blocksPos[227, 0] = 0f;
        blocksPos[227, 1] = .250f;

        blocksPos[228, 0] = .0f;
        blocksPos[228, 1] =.30f;
        //
        blocksPos[229, 0] =0f;
        blocksPos[229, 1] =0f;

        blocksPos[230, 0] = 0f;
        blocksPos[230, 1] = 0f;

        blocksPos[231, 0] =0f;
        blocksPos[231, 1] =0f;

        blocksPos[232, 0] =0f;
        blocksPos[232, 1] =0f;

        blocksPos[233, 0] = 0f;
        blocksPos[233, 1] =0f;

        blocksPos[234, 0] = 0f;
        blocksPos[234, 1] =0f;
        //
        blocksPos[235, 0] = .30f;
        blocksPos[235, 1] = .40f;

        blocksPos[236, 0] = 0f;
        blocksPos[236, 1] = .350f;

        blocksPos[237, 0] =-.20f;
        blocksPos[237, 1] = .30f;

        blocksPos[238, 0] =-.220f;
        blocksPos[238, 1] =-.250f;

        blocksPos[239, 0] = 0f;
        blocksPos[239, 1] = 0f;

        blocksPos[240, 0] = 0f;
        blocksPos[240, 1] =-.10f;

        blocksPos[241, 0] = .20f;
        blocksPos[241, 1] = 0f;

        blocksPos[242, 0] = .30f;
        blocksPos[242, 1] =-.10f;

        blocksPos[243, 0] = 0f;
        blocksPos[243, 1] = .30f;

        blocksPos[244, 0] = .20f;
        blocksPos[244, 1] = 0f;

        blocksPos[245, 0] =-.20f;
        blocksPos[245, 1] = .30f;
        //
        blocksPos[246, 0] = 0f;
        blocksPos[246, 1] = .0140f;

        blocksPos[247, 0] =-.0520f;
        blocksPos[247, 1] =.10f;

        blocksPos[248, 0] = .0230f;
        blocksPos[248, 1] =.20f;

        blocksPos[249, 0] =-.0710f;
        blocksPos[249, 1] = .1830f;

        blocksPos[250, 0] =-.0730f;
        blocksPos[250, 1] = .20f;

        blocksPos[251, 0] =-.0310f;
        blocksPos[251, 1] = .30f;

        blocksPos[252, 0] = .30f;
        blocksPos[252, 1] = .20f;

        blocksPos[253, 0] = .30f;
        blocksPos[253, 1] = .30f;

        blocksPos[254, 0] = .10f;
        blocksPos[254, 1] =-.20f;

        blocksPos[255, 0] =-.30f;
        blocksPos[255, 1] = 0f;

        blocksPos[256, 0] =-.10f;
        blocksPos[256, 1] = .10f;

        blocksPos[257, 0] = .20f;
        blocksPos[257, 1] = .20f;
        //
        blocksPos[258, 0] = 0f;
        blocksPos[258, 1] = .20f;

        blocksPos[259, 0] =-.030f;
        blocksPos[259, 1] = .140f;

        blocksPos[260, 0] =-.040f;
        blocksPos[260, 1] = .1020f;

        blocksPos[261, 0] = .10f;
        blocksPos[261, 1] = 0f;

        blocksPos[262, 0] =-.120f;
        blocksPos[262, 1] =-.0f;

        blocksPos[263, 0] = .130f;
        blocksPos[263, 1] =-.20f;
        //
        blocksPos[264, 0] = .20f;
        blocksPos[264, 1] =-.20f;

        blocksPos[265, 0] = .20f;
        blocksPos[265, 1] = 0f;

        blocksPos[266, 0] = .10f;
        blocksPos[266, 1] = .30f;

        blocksPos[267, 0] =-.40f;
        blocksPos[267, 1] = 0f;

        blocksPos[268, 0] = .20f;
        blocksPos[268, 1] = 0f;

        blocksPos[269, 0] =-.10f;
        blocksPos[269, 1] =-.10f;
        //
        blocksPos[270, 0] = .20f;
        blocksPos[270, 1] =-.10f;

        blocksPos[271, 0] = .20f;
        blocksPos[271, 1] = -.20f;

        blocksPos[272, 0] = .130f;
        blocksPos[272, 1] = 0f;

        blocksPos[273, 0] = 0f;
        blocksPos[273, 1] = .40f;

        blocksPos[274, 0] = .20f;
        blocksPos[274, 1] = .20f;

        blocksPos[275, 0] = .20f;
        blocksPos[275, 1] =-.30f;
        //
        blocksPos[276, 0] =-.10f;
        blocksPos[276, 1] = .10f;

        blocksPos[277, 0] = -.150f;
        blocksPos[277, 1] =-.20f;

        blocksPos[278, 0] = -.30f;
        blocksPos[278, 1] = .30f;

        blocksPos[279, 0] = -.20f;
        blocksPos[279, 1] = 0f;

        blocksPos[280, 0] =-.30f;
        blocksPos[280, 1] =-.10f;

        blocksPos[281, 0] =-.10f;
        blocksPos[281, 1] = .20f;
        //
        blocksPos[282, 0] = .20f;
        blocksPos[282, 1] = 0f;

        blocksPos[283, 0] = .30f;
        blocksPos[283, 1] =-.20f;

        blocksPos[284, 0] = .20f;
        blocksPos[284, 1] = .10f;

        blocksPos[285, 0] = .20f;
        blocksPos[285, 1] =-.20f;

        blocksPos[286, 0] =-.20f;
        blocksPos[286, 1] = .30f;
        
        blocksPos[287, 0] = 0f;
        blocksPos[287, 1] = 0f;

        blocksPos[288, 0] = .30f;
        blocksPos[288, 1] = 0f;

        blocksPos[289, 0] = .40f;
        blocksPos[289, 1] =-.20f;

        blocksPos[290, 0] =-.20f;
        blocksPos[290, 1] = .20f;

        blocksPos[291, 0] =-.20f;
        blocksPos[291, 1] =-.20f;

        blocksPos[292, 0] =-.30f;
        blocksPos[292, 1] = .20f;
        
        blocksPos[293, 0] = 0f;
        blocksPos[293, 1] =-.20f;

        blocksPos[294, 0] = 0f;
        blocksPos[294, 1] = 0f;

        blocksPos[295, 0] =-.30f;
        blocksPos[295, 1] = .20f;

        blocksPos[296, 0] =-.30f;
        blocksPos[296, 1] = .38720f;

        blocksPos[297, 0] = .30f;
        blocksPos[297, 1] = .03220f;

        blocksPos[298, 0] =-.2870f;
        blocksPos[298, 1] = .1160f;

        blocksPos[299, 0] =-.40f;
        blocksPos[299, 1] = .1623420f;



        //ORIENTATION

        orientation[0, 1] = 0;

        orientation[1, 0] = 0;
        orientation[1, 1] = 0;

        orientation[2, 0] = 0;
        orientation[2, 1] = 0;

        orientation[3, 0] = 0;
        orientation[3, 1] = 0;

        orientation[4, 0] = 0;
        orientation[4, 1] = 0;

        orientation[5, 0] = 0;
        orientation[5, 1] = 0;

        orientation[6, 0] = 0;
        orientation[6, 1] = 0;

        orientation[7, 0] = 0;
        orientation[7, 1] = 0;

        orientation[8, 0] = 0;
        orientation[8, 1] = 0;

        orientation[9, 0] = 0;
        orientation[9, 1] = 0;

        orientation[10, 0] = 0;
        orientation[10, 1] = 0;

        orientation[11, 0] = 0;
        orientation[11, 1] = 0;

        orientation[12, 0] = 1;
        orientation[12, 1] = 0;

        orientation[13, 0] = 0;
        orientation[13, 1] = 1;

        orientation[14, 0] = 0;
        orientation[14, 1] = 0;

        orientation[15, 0] = 0;
        orientation[15, 1] = 0;

        orientation[16, 0] = 0;
        orientation[16, 1] = 0;

        orientation[17, 0] = 0;
        orientation[17, 1] = 0;
        //
        orientation[18, 0] = 1;
        orientation[18, 1] = 0;

        orientation[19, 0] = 1;
        orientation[19, 1] = 0;

        orientation[20, 0] = 1;
        orientation[20, 1] = 0;

        orientation[21, 0] = 0;
        orientation[21, 1] = 0;

        orientation[22, 0] = 1;
        orientation[22, 1] = 0;

        orientation[23, 0] = 1;
        orientation[23, 1] = 0;
        //
        orientation[24, 0] = 1;
        orientation[24, 1] = 0;

        orientation[25, 0] = 0;
        orientation[25, 1] = 1;

        orientation[26, 0] = 1;
        orientation[26, 1] = 0;

        orientation[27, 0] = 01;
        orientation[27, 1] = 0;

        orientation[28, 0] = 0;
        orientation[28, 1] = 0;

        orientation[29, 0] = 0;
        orientation[29, 1] = 1;
        //
        orientation[30, 0] = 0;
        orientation[30, 1] = 01;

        orientation[31, 0] = 0;
        orientation[31, 1] = 0;

        orientation[32, 0] = 0;
        orientation[32, 1] = 0;

        orientation[33, 0] = 01;
        orientation[33, 1] = 0;

        orientation[34, 0] = 0;
        orientation[34, 1] = 0;

        orientation[35, 0] = 0;
        orientation[35, 1] = 0;
        //
        orientation[36, 0] = 0;
        orientation[36, 1] = 1;

        orientation[37, 0] = 0;
        orientation[37, 1] = 0;

        orientation[38, 0] = 0;
        orientation[38, 1] = 0;

        orientation[39, 0] = 0;
        orientation[39, 1] = 0;

        orientation[40, 0] = 0;
        orientation[40, 1] = 0;

        orientation[41, 0] = 1;
        orientation[41, 1] = 0;
        //
        orientation[42, 0] = 0;
        orientation[42, 1] = 01;

        orientation[43, 0] = 01;
        orientation[43, 1] = 0;

        orientation[44, 0] = 01;
        orientation[44, 1] = 01;

        orientation[45, 0] = 01;
        orientation[45, 1] = 0;

        orientation[46, 0] = 0;
        orientation[46, 1] = 01;

        orientation[47, 0] = 0;
        orientation[47, 1] = 01;
        //
        orientation[48, 0] = 01;
        orientation[48, 1] = 0;

        orientation[49, 0] = 01;
        orientation[49, 1] = 01;

        orientation[50, 0] = 0;
        orientation[50, 1] = 01;

        orientation[51, 0] = 0;
        orientation[51, 1] = 0;

        orientation[52, 0] = 01;
        orientation[52, 1] = 0;

        orientation[53, 0] = 0;
        orientation[53, 1] = 01;
        //
        orientation[54, 0] = 01;
        orientation[54, 1] = 0;

        orientation[55, 0] = 01;
        orientation[55, 1] = 01;

        orientation[56, 0] = 01;
        orientation[56, 1] = 01;

        orientation[57, 0] = 0;
        orientation[57, 1] = 0;

        orientation[58, 0] = 0;
        orientation[58, 1] = 01;

        orientation[59, 0] = 01;
        orientation[59, 1] = 0;
        //
        orientation[60, 0] = 0;
        orientation[60, 1] = 0;

        orientation[61, 0] = 0;
        orientation[61, 1] = 01;

        orientation[62, 0] = 0;
        orientation[62, 1] = 0;

        orientation[63, 0] = 0;
        orientation[63, 1] = 01;

        orientation[64, 0] = 0;
        orientation[64, 1] = 0;

        orientation[65, 0] = 01;
        orientation[65, 1] = 0;
        //
        orientation[66, 0] = 0;
        orientation[66, 1] = 0;

        orientation[67, 0] = 01;
        orientation[67, 1] = 0;

        orientation[68, 0] = 0;
        orientation[68, 1] = 0;

        orientation[69, 0] = 01;
        orientation[69, 1] = 0;

        orientation[70, 0] = 0;
        orientation[70, 1] = 01;

        orientation[71, 0] = 01;
        orientation[71, 1] = 0;
        //
        orientation[72, 0] = 0;
        orientation[72, 1] = 0;

        orientation[73, 0] = 0;
        orientation[73, 1] = 0;

        orientation[74, 0] = 0;
        orientation[74, 1] = 0;

        orientation[75, 0] = 0;
        orientation[75, 1] = 0;

        orientation[76, 0] = 0;
        orientation[76, 1] = 0;

        orientation[77, 0] = 1;
        orientation[77, 1] = 0;
        //
        orientation[78, 0] = 01;
        orientation[78, 1] = 0;

        orientation[79, 0] = 0;
        orientation[79, 1] = 0;

        orientation[80, 0] = 0;
        orientation[80, 1] = 01;

        orientation[81, 0] = 01;
        orientation[81, 1] = 0;

        orientation[82, 0] = 01;
        orientation[82, 1] = 0;

        orientation[83, 0] = 01;
        orientation[83, 1] = 01;
        //
        orientation[84, 0] = 0;
        orientation[84, 1] = 0;

        orientation[85, 0] = 0;
        orientation[85, 1] = 0;

        orientation[86, 0] = 0;
        orientation[86, 1] = 0;

        orientation[87, 0] = 0;
        orientation[87, 1] = 01;

        orientation[88, 0] = 0;
        orientation[88, 1] = 01;

        orientation[89, 0] = 0;
        orientation[89, 1] = 01;
        //
        orientation[90, 0] = 1;
        orientation[90, 1] = 0;

        orientation[91, 0] = 0;
        orientation[91, 1] = 01;

        orientation[92, 0] = 01;
        orientation[92, 1] = 0;

        orientation[93, 0] = 0;
        orientation[93, 1] = 01;

        orientation[94, 0] = 0;
        orientation[94, 1] = 0;

        orientation[95, 0] = 0;
        orientation[95, 1] = 0;
        //
        orientation[96, 0] = 01;
        orientation[96, 1] = 0;

        orientation[97, 0] = 0;
        orientation[97, 1] = 01;

        orientation[98, 0] = 01;
        orientation[98, 1] = 01;

        orientation[99, 0] = 0;
        orientation[99, 1] = 01;

        orientation[100, 0] = 0;
        orientation[100, 1] = 01;

        orientation[101, 0] = 0;
        orientation[101, 1] = 0;
        //
        orientation[102, 0] = 01;
        orientation[102, 1] = 01;

        orientation[103, 0] = 0;
        orientation[103, 1] = 0;

        orientation[104, 0] = 01;
        orientation[104, 1] = 0;

        orientation[105, 0] = 0;
        orientation[105, 1] = 01;

        orientation[106, 0] = 0;
        orientation[106, 1] = 0;

        orientation[107, 0] = 0;
        orientation[107, 1] = 01;
        //
        orientation[108, 0] = 01;
        orientation[108, 1] = 0;

        orientation[109, 0] = 0;
        orientation[109, 1] = 0;

        orientation[110, 0] = 0;
        orientation[110, 1] = 01;

        orientation[111, 0] = 01;
        orientation[111, 1] = 0;

        orientation[112, 0] = 0;
        orientation[112, 1] = 0;

        orientation[113, 0] = 0;
        orientation[113, 1] = 01;
        //
        orientation[114, 0] = 0;
        orientation[114, 1] = 01;

        orientation[115, 0] = 0;
        orientation[115, 1] = 01;

        orientation[116, 0] = 01;
        orientation[116, 1] = 01;

        orientation[117, 0] = 01;
        orientation[117, 1] = 0;

        orientation[118, 0] = 0;
        orientation[118, 1] = 01;

        orientation[119, 0] = 01;
        orientation[119, 1] = 0;
        //
        orientation[120, 0] = 01;
        orientation[120, 1] = 01;

        orientation[121, 0] = 0;
        orientation[121, 1] = 01;

        orientation[122, 0] = 01;
        orientation[122, 1] = 0;

        orientation[123, 0] = 0;
        orientation[123, 1] = 01;

        orientation[124, 0] = 0;
        orientation[124, 1] = 0;

        orientation[125, 0] = 0;
        orientation[125, 1] = 0;

        orientation[126, 0] = 01;
        orientation[126, 1] = 0;

        orientation[127, 0] = 0;
        orientation[127, 1] = 01;

        orientation[128, 0] = 01;
        orientation[128, 1] = 01;

        orientation[129, 0] = 0;
        orientation[129, 1] = 01;

        orientation[130, 0] = 0;
        orientation[130, 1] = 0;

        orientation[131, 0] = 01;
        orientation[131, 1] = 0;

        orientation[132, 0] = 0;
        orientation[132, 1] = 01;

        orientation[133, 0] = 0;
        orientation[133, 1] = 01;

        orientation[134, 0] = 01;
        orientation[134, 1] = 0;

        orientation[135, 0] = 01;
        orientation[135, 1] = 0;

        orientation[136, 0] = 0;
        orientation[136, 1] = 01;

        orientation[137, 0] = 0;
        orientation[137, 1] = 01;

        orientation[138, 0] = 01;
        orientation[138, 1] = 0;

        orientation[139, 0] = 0;
        orientation[139, 1] = 0;

        orientation[140, 0] = 01;
        orientation[140, 1] = 0;

        orientation[141, 0] = 01;
        orientation[141, 1] = 0;

        orientation[142, 0] = 01;
        orientation[142, 1] = 0;

        orientation[143, 0] = 01;
        orientation[143, 1] = 0;

        orientation[144, 0] = 0;
        orientation[144, 1] = 01;

        orientation[145, 0] = 01;
        orientation[145, 1] = 0;

        orientation[146, 0] = 0;
        orientation[146, 1] = 01;

        orientation[147, 0] = 0;
        orientation[147, 1] = 0;

        orientation[148, 0] = 0;
        orientation[148, 1] = 0;

        orientation[149, 0] = 0;
        orientation[149, 1] = 01;

        orientation[150, 0] = 0;
        orientation[150, 1] = 01;

        orientation[151, 0] = 0;
        orientation[151, 1] = 01;

        orientation[152, 0] = 01;
        orientation[152, 1] = 0;

        orientation[153, 0] = 01;
        orientation[153, 1] = 0;

        orientation[154, 0] = 0;
        orientation[154, 1] = 01;

        orientation[155, 0] = 01;
        orientation[155, 1] = 01;

        orientation[156, 0] = 01;
        orientation[156, 1] = 0;

        orientation[157, 0] = 0;
        orientation[157, 1] = 01;

        orientation[158, 0] = 0;
        orientation[158, 1] = 0;

        orientation[159, 0] = 0;
        orientation[159, 1] = 0;

        orientation[160, 0] = 0;
        orientation[160, 1] = 01;

        orientation[161, 0] = 01;
        orientation[161, 1] = 0;

        orientation[162, 0] = 01;
        orientation[162, 1] = 01;

        orientation[163, 0] = 0;
        orientation[163, 1] = 01;

        orientation[164, 0] = 0;
        orientation[164, 1] = 0;

        orientation[165, 0] = 0;
        orientation[165, 1] = 01;

        orientation[166, 0] = 0;
        orientation[166, 1] = 01;

        orientation[167, 0] = 01;
        orientation[167, 1] = 0;

        orientation[168, 0] = 01;
        orientation[168, 1] = 0;

        orientation[169, 0] = 01;
        orientation[169, 1] = 0;

        orientation[170, 0] = 01;
        orientation[170, 1] = 0;

        orientation[171, 0] = 0;
        orientation[171, 1] = 01;

        orientation[172, 0] = 0;
        orientation[172, 1] = 0;

        orientation[173, 0] = 0;
        orientation[173, 1] = 01;

        orientation[174, 0] = 0;
        orientation[174, 1] = 01;

        orientation[175, 0] = 01;
        orientation[175, 1] = 0;

        orientation[176, 0] = 01;
        orientation[176, 1] = 01;

        orientation[177, 0] = 0;
        orientation[177, 1] = 01;

        orientation[178, 0] = 0;
        orientation[178, 1] = 0;

        orientation[179, 0] = 0;
        orientation[179, 1] = 0;

        orientation[180, 0] = 01;
        orientation[180, 1] = 0;

        orientation[181, 0] = 0;
        orientation[181, 1] = 01;

        orientation[182, 0] = 0;
        orientation[182, 1] = 01;

        orientation[183, 0] = 0;
        orientation[183, 1] = 01;

        orientation[184, 0] = 01;
        orientation[184, 1] = 0;

        orientation[185, 0] = 0;
        orientation[185, 1] = 0;

        orientation[186, 0] = 0;
        orientation[186, 1] = 0;

        orientation[187, 0] = 01;
        orientation[187, 1] = 0;

        orientation[188, 0] = 0;
        orientation[188, 1] = 0;

        orientation[189, 0] = 0;
        orientation[189, 1] = 01;

        orientation[190, 0] = 01;
        orientation[190, 1] = 0;

        orientation[191, 0] = 0;
        orientation[191, 1] = 01;

        orientation[192, 0] = 0;
        orientation[192, 1] = 01;

        orientation[193, 0] = 0;
        orientation[193, 1] = 01;

        orientation[194, 0] = 01;
        orientation[194, 1] = 0;

        orientation[195, 0] = 0;
        orientation[195, 1] = 0;

        orientation[196, 0] = 0;
        orientation[196, 1] = 0;

        orientation[197, 0] = 01;
        orientation[197, 1] = 0;

        orientation[198, 0] = 0;
        orientation[198, 1] = 0;

        orientation[199, 0] = 0;
        orientation[199, 1] = 01;

        orientation[200, 0] = 0;
        orientation[200, 1] = 0;

        orientation[201, 0] = 0;
        orientation[201, 1] = 01;

        orientation[202, 0] = 0;
        orientation[202, 1] = 0;

        orientation[203, 0] = 01;
        orientation[203, 1] = 0;

        orientation[204, 0] = 01;
        orientation[204, 1] = 01;

        orientation[205, 0] = 0;
        orientation[205, 1] = 01;

        orientation[206, 0] = 0;
        orientation[206, 1] = 01;

        orientation[207, 0] = 01;
        orientation[207, 1] = 0;

        orientation[208, 0] = 0;
        orientation[208, 1] = 0;

        orientation[209, 0] = 0;
        orientation[209, 1] = 0;

        orientation[210, 0] = 01;
        orientation[210, 1] = 0;

        orientation[211, 0] = 0;
        orientation[211, 1] = 01;

        orientation[212, 0] = 0;
        orientation[212, 1] = 01;

        orientation[213, 0] = 01;
        orientation[213, 1] = 0;

        orientation[214, 0] = 0;
        orientation[214, 1] = 01;

        orientation[215, 0] = 0;
        orientation[215, 1] = 0;

        orientation[216, 0] = 01;
        orientation[216, 1] = 01;

        orientation[217, 0] = 0;
        orientation[217, 1] = 0;

        orientation[218, 0] = 0;
        orientation[218, 1] = 01;

        orientation[219, 0] = 0;
        orientation[219, 1] = 01;

        orientation[220, 0] = 0;
        orientation[220, 1] = 0;

        orientation[221, 0] = 01;
        orientation[221, 1] = 0;

        orientation[222, 0] = 01;
        orientation[222, 1] = 0;

        orientation[223, 0] = 0;
        orientation[223, 1] = 01;

        orientation[224, 0] = 01;
        orientation[224, 1] = 0;

        orientation[225, 0] = 0;
        orientation[225, 1] = 01;

        orientation[226, 0] = 01;
        orientation[226, 1] = 0;

        orientation[227, 0] = 0;
        orientation[227, 1] = 01;

        orientation[228, 0] = 0;
        orientation[228, 1] = 0;

        orientation[229, 0] = 0;
        orientation[229, 1] = 01;

        orientation[230, 0] = 01;
        orientation[230, 1] = 0;

        orientation[231, 0] = 01;
        orientation[231, 1] = 01;

        orientation[232, 0] = 0;
        orientation[232, 1] = 01;

        orientation[233, 0] = 0;
        orientation[233, 1] = 0;

        orientation[234, 0] = 0;
        orientation[234, 1] = 0;

        orientation[235, 0] = 0;
        orientation[235, 1] = 01;

        orientation[236, 0] = 0;
        orientation[236, 1] = 0;

        orientation[237, 0] = 01;
        orientation[237, 1] = 0;

        orientation[238, 0] = 0;
        orientation[238, 1] = 0;

        orientation[239, 0] = 0;
        orientation[239, 1] = 01;

        orientation[240, 0] = 0;
        orientation[240, 1] = 01;

        orientation[241, 0] = 0;
        orientation[241, 1] = 0;

        orientation[242, 0] = 01;
        orientation[242, 1] = 0;

        orientation[243, 0] = 01;
        orientation[243, 1] = 0;

        orientation[244, 0] = 0;
        orientation[244, 1] = 0;

        orientation[245, 0] = 0;
        orientation[245, 1] = 01;

        orientation[246, 0] = 0;
        orientation[246, 1] = 01;

        orientation[247, 0] = 0;
        orientation[247, 1] = 01;

        orientation[248, 0] = 0;
        orientation[248, 1] = 0;

        orientation[249, 0] = 01;
        orientation[249, 1] = 0;

        orientation[250, 0] = 01;
        orientation[250, 1] = 0;

        orientation[251, 0] = 0;
        orientation[251, 1] = 01;

        orientation[252, 0] = 0;
        orientation[252, 1] = 0;

        orientation[253, 0] = 0;
        orientation[253, 1] = 01;

        orientation[254, 0] = 0;
        orientation[254, 1] = 01;

        orientation[255, 0] = 01;
        orientation[255, 1] = 0;

        orientation[256, 0] = 0;
        orientation[256, 1] = 0;

        orientation[257, 0] = 0;
        orientation[257, 1] = 01;

        orientation[258, 0] = 0;
        orientation[258, 1] = 0;

        orientation[259, 0] = 0;
        orientation[259, 1] = 0;

        orientation[260, 0] = 01;
        orientation[260, 1] = 0;

        orientation[261, 0] = 0;
        orientation[261, 1] = 0;

        orientation[262, 0] = 01;
        orientation[262, 1] = 0;

        orientation[263, 0] = 0;
        orientation[263, 1] = 01;

        orientation[264, 0] = 01;
        orientation[264, 1] = 0;

        orientation[265, 0] = 01;
        orientation[265, 1] = 0;

        orientation[266, 0] = 0;
        orientation[266, 1] = 01;

        orientation[267, 0] = 0;
        orientation[267, 1] = 0;

        orientation[268, 0] = 0;
        orientation[268, 1] = 0;

        orientation[269, 0] = 0;
        orientation[269, 1] = 0;

        orientation[270, 0] = 0;
        orientation[270, 1] = 01;

        orientation[271, 0] = 0;
        orientation[271, 1] = 01;

        orientation[272, 0] = 01;
        orientation[272, 1] = 0;

        orientation[273, 0] = 0;
        orientation[273, 1] = 01;

        orientation[274, 0] = 0;
        orientation[274, 1] = 01;

        orientation[275, 0] = 0;
        orientation[275, 1] = 0;

        orientation[276, 0] = 0;
        orientation[276, 1] = 0;

        orientation[277, 0] = 0;
        orientation[277, 1] = 01;

        orientation[278, 0] = 01;
        orientation[278, 1] = 0;

        orientation[279, 0] = 01;
        orientation[279, 1] = 01;

        orientation[280, 0] = 0;
        orientation[280, 1] = 0;

        orientation[281, 0] = 01;
        orientation[281, 1] = 0;

        orientation[282, 0] = 0;
        orientation[282, 1] = 01;

        orientation[283, 0] = 0;
        orientation[283, 1] = 0;

        orientation[284, 0] = 01;
        orientation[284, 1] = 0;

        orientation[285, 0] = 0;
        orientation[285, 1] = 01;

        orientation[286, 0] = 0;
        orientation[286, 1] = 01;

        orientation[287, 0] = 01;
        orientation[287, 1] = 0;

        orientation[288, 0] = 0;
        orientation[288, 1] = 0;

        orientation[289, 0] = 0;
        orientation[289, 1] = 0;

        orientation[290, 0] = 0;
        orientation[290, 1] = 01;

        orientation[291, 0] = 0;
        orientation[291, 1] = 01;

        orientation[292, 0] = 0;
        orientation[292, 1] = 01;

        orientation[293, 0] = 01;
        orientation[293, 1] = 0;

        orientation[294, 0] = 0;
        orientation[294, 1] = 0;

        orientation[295, 0] = 0;
        orientation[295, 1] = 01;

        orientation[296, 0] = 01;
        orientation[296, 1] = 0;

        orientation[297, 0] = 01;
        orientation[297, 1] = 0;

        orientation[298, 0] = 0;
        orientation[298, 1] = 0;

        orientation[299, 0] = 0;
        orientation[299, 1] = 0;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
