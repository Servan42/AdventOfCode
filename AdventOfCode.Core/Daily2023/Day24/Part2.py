import sympy

hailstonesText = [
    # "19, 13, 30 @ -2,  1, -2",
    # "18, 19, 22 @ -1, -1, -2",
    # "20, 25, 34 @ -2, -2, -4",
    # "12, 31, 28 @ -1, -2, -1",
    # "20, 19, 15 @  1, -5, -3",
    "219051609191782, 68260434807407, 317809635461867 @ 146, 364, -22",
    "292151991892724, 394725036264709, 272229701860796 @ -43, -280, -32",
    "455400538938496, 167482380286201, 389150487664328 @ -109, 219, -58",
    "199597051713828, 198498491378597, 230104579246572 @ 134, 104, -62",
    "367935067813454, 358033491577763, 300052079497308 @ -33, -17, 27",
    "239730316398484, 322209632306829, 343431553310564 @ 86, -85, -154",
    "246742202475134, 333490255115089, 398751268615964 @ 99, -36, -165",
    "204424990569080, 172605788927383, 149785389522746 @ 138, 219, 266",
    "172082527043795, 158439310305133, 234013400813615 @ 255, 282, -58"
    ]

hailstones = [tuple(map(int, line.replace("@", ",").split(","))) for line in hailstonesText]

rockX, rockY, rockZ, rockVx, rockVy, rockVz = sympy.symbols("rockX, rockY, rockZ, rockVx, rockVy, rockVz")

equations = []

for sx, sy, sz, vx, vy, vz in hailstones:
    equations.append((rockX - sx) * (vy - rockVy) - (rockY - sy) * (vx - rockVx))
    equations.append((rockY - sy) * (vz - rockVz) - (rockZ - sz) * (vy - rockVy))

answers = sympy.solve(equations)
print(answers[0][rockX] + answers[0][rockY] + answers[0][rockZ])