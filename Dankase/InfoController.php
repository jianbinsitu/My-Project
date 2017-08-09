<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\Controller;

class InfoController extends Controller
{
    public function insertInfo(Request $request){
        $Info = [];
        $Info['email'] = $request->input('email');
        $Info['comment'] = $request->input('comment');
        $Info['origin'] = $request->input('origin');
        $Info['model'] = $request->input('model');
        $insert = DB::insert('insert into notifylist (email, comment, phone, origin) values (?, ?, ?, ?)', [$Info['email'], $Info['comment'], $Info['model'],$Info['origin']]);
    }

}