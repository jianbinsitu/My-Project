<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\Controller;
use Mail;

class InfoController extends Controller
{
    public function insertInfo(Request $request){
        $Info = [];
        $Info['email'] = $request->input('email');
        $Info['comment'] = $request->input('comment');
        $Info['origin'] = $request->input('origin');
        $Info['model'] = $request->input('model');
        $welcome = "Dear Valued Customer,";
        $p1 = "We¡¯re truly sorry to inform you that our product is not yet ready.";
        $p2 = "Be patient as we gather the proper things necessary to make this for you.";
        $p3 = "In the meanwhile, here is a $10 coupon off your next purchase.";
        $p4 = "Sincerely,";
        $p5 = "Team Danky";
        $p6 = "P.S We love you and thanks for making our dreams come true!";
        $coupon = "Coupon Code: TENDY10";
        $insert = DB::insert('insert into notifylist (email, comment, phone, origin) values (?, ?, ?, ?)', [$Info['email'], $Info['comment'], $Info['model'],$Info['origin']]);
    	Mail::send('emails.send',['welcome'=> $welcome, 'p1'=>$p1, 'p2'=>$p2, 'p3'=>$p3, 'p4'=>$p4,'p5'=>$p5,'p6'=>$p6,'coupon'=> $coupon],function($message) use ($Info){
            $message->to($Info['email'], 'Subscriber')->subject('Welcome');
        });
	
    }

    public function checkEmail(Request $request){
        $email = $request->input('email');
        $check = DB::select('select email from notifylist where (?) = email', [$email]);
        if($check != null){
            return 'This Email Has Already Been Subscribe Please Use Another Email!';
        }
        else{
            return;
        }
    }

}