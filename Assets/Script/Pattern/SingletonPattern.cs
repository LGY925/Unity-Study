using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /****************************************************
     *              디자인 패턴 Singleton               *
     ****************************************************/

    /*
     * <싱글톤 패턴>
     * 오직 한 개의 클래스 인스턴스만을 갖도록 보장
     * 이에 대한 전역적인 접근점을 제공
     * 
     * 
     * <구현>
     * 1. 단일 인스턴스를 유지하기 위해 생성자의 접근권한을 외부에서 생성할 수 없도록 제한
     * 2. 단일 인스턴스를 보관할 정적 변수를 구성
     * 3. 외부에서 접근이 가능한 GetInstance 함수를 구성
     * 4. GetInstance 함수에서 단일 인스턴스가 없을 경우 인스턴스를 생성하여 정적 변수에 참조
     * 5. GetInstance 함수에서 단일 인스턴스가 있을 경우 정적 변수에 참조된 인스턴스를 반환
     * 
     * <장점>
     * 1. 하나뿐인 존재로 주요 클래스 & 관리자 역할에 적합함
     * 2. 전역적 접근으로 참조에 필요한 작업이 없이 빠른 접근이 가능함
     * 3. 인스턴스들이 싱글톤을 통하여 데이터를 공유하기 쉬워짐
     * 
     * <주의점>
     * 1. 싱글톤은 너무 많은 책임을 짊어지는 경우가 많으며 단일책임원칙을 위반
     * 2. 싱글톤은 전역접근으로 코드의 결합도를 높이므로 남발하지 않아야함
     * 3. 싱글톤은 단위 테스트를 하기 어렵게 함
     */
namespace Patten
{
    public class Singleton
    {
        private static Singleton instance;

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }

        private Singleton() { }
    }
}
