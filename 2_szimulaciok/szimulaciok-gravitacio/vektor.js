class Vektor{
    constructor(x,y){
        this.x = x;
        this.y = y;
    }

    // +  -
    static osszead(u,v){
        return new Vektor(u.x+v.x, u.y+v.y);
    }
    static kivon(u,v){
        return new Vektor(u.x+v.x, u.y+v.y);
    }
    
    hozzaad(that){
        this.x += that.x;
        this.y += that.y;
        return this;
    }


    static ellentett(u,v){
        return new Vektor(-u.x, -u.y);
    }


    static balraforgat90(u,v){
        return new Vektor(-u.y, u.x);
    }

    static jobbraforgat90(u,v){
        return new Vektor(u.y, -u.x);
    }


    static szamszoroz(u,a){
        return new Vektor(u.x*a, u.y*a);
    }


    hossz(){
        return Math.sqrt(this.hossznegyzet());
    }
    hossznegyzet(){
        return this.x**2 + this.y**2;
    }


    egysegvektora(){
        return new Vektor(this.x/this.hossz(), this.y/this.hossz())
    }


    // skalarszoroz(u,v){
        
    // }

    szamosztva(u,v){
        
    }


    
    


}


u = new Vektor(5, 4);
v = new Vektor(2, 1);

u.plusz(v)