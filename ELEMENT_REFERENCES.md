# Potion Shift — 원소 체계 레퍼런스 조사

조사일: 2026-09-08

## 범위와 확인 수준

44개 검색어로 게임, 마법 모드, 역사적 원소 체계와 설계 글을 검색하고 관련 자료 35개를 추렸다. 35개 게임을 조사했다는 뜻은 아니다. 검색 결과의 본문 발췌를 확인한 자료와 원문을 추가로 연 자료는 아래에서 구분한다. 무관한 결과와 출처 불명의 재업로드 PDF는 추천에서 제외했다. 본 문서는 조사 메모이며 GDD의 확정 설정을 변경하지 않는다.

## 핵심 발견

- Thaumcraft 공식 API는 빛=공기+불, 생명=흙+물처럼 부모 원소 두 개로 추상적 성질을 정의한다. 모든 쌍에 결과를 강제로 부여하지는 않는다. API master에는 불+물과 불+흙의 미정 주석이 있다. 버전별 조합은 다르므로 4.2 위키와 master를 합쳐 단일 표로 만들면 안 된다.
- Potion Craft의 2022년 Devlog 16은 공기·마법·물·생명·흙·독·불·폭발의 8방향 체계를 제안한다. 물과 흙 사이에 생명, 불과 공기 사이에 폭발을 배치한다. 이는 방향별 계열 설계이며 기본 원소 두 개의 고정 합성식이 아니다. 개발 중 글이므로 현재 구현의 전체 명세로 취급하지 않는다.
- Magicka는 조합을 주문 행동으로 연결한다. 물+불=증기 외에도 생명+방어로 회복 지뢰를 만드는 예시가 있어 추상적인 속성 조합도 실제 행동으로 이해시킨다.
- Little Alchemy는 에너지와 생명 같은 추상 개념을 쓰지만 사물 발견의 폭이 넓다. 전체 조합표를 가져오기보다 여러 경로로 같은 개념에 도달하는 점을 참고할 만하다.
- Magic의 color pie는 계열의 철학과 가능한 행동·불가능한 행동을 먼저 정한다. Potion Shift에도 조합 이름을 먼저 채우기보다 기본 원소의 역할을 정의하는 방식이 유용하다.

## Potion Shift 적용 제안 — 미확정

기본 원소 4개와 약초 4종은 유지한다. 각 원소에 짧고 구분되는 의미를 부여한 뒤 6개 조합을 결정한다. 예를 들어 불은 활성·변화, 물은 순환·회복, 흙은 형태·유지, 바람은 이동·전달을 후보로 볼 수 있다. 이는 기존 작품의 공식 설정이나 확정 기획이 아닌 독자적인 설계 제안이다.

빛·생명은 우선 비교하기 좋은 후보다. 운동·결속·변성·감응 등은 약초 도감 설명과 포션 효능에 연결되는지 검토해야 한다. 여섯 조합의 최종 이름은 이번 조사만으로 확정하지 않는다.

## 자료 목록

| 번호 | 자료 | 확인 수준 | 내용과 활용 |
| --- | --- | --- | --- |
| 1 | [Thaumcraft 공식 Aspect 정의](https://github.com/Azanor/thaumcraft-api/blob/master/aspects/Aspect.java) | 1차·본문 확인 | 빛·생명·운동·감각 등 개념을 두 부모 원소로 정의. master와 과거 버전 조합을 혼용하지 말 것. |
| 2 | [Thaumcraft 4.2 원소 목록](https://thaumcraft-4.fandom.com/wiki/Aspects) | 커뮤니티·검색 본문 | 4.2와 이전 버전 차이 비교용. 공식 API master의 동일 버전 자료로 취급하지 않음. |
| 3 | [Thaumcraft 4 연구](https://thaumcraft4.fandom.com/wiki/Research) | 커뮤니티·검색 본문 | 부모·자식 원소를 연결하는 연구 구조. 제조 반응과 연구 관계 구분. |
| 4 | [Potion Craft Devlog 16](https://store.steampowered.com/news/posts/?enddate=1653320010&feed=steam_community_announcements) | 1차·본문 확인 | 2022-05-23 개발 중 설계: 공기·마법·물·생명·흙·독·불·폭발의 8방향. 고정 합성표는 아님. |
| 5 | [Potion Craft 공식 소개](https://store.steampowered.com/app/1210320/Potion_Craft_Alchemist_Simulator/) | 1차·본문 확인 | 도구 조작, 분쇄, 지도 경로, 효과 조합과 병·라벨 사용자화. |
| 6 | [Potion Craft Xbox 소개](https://news.xbox.com/en-us/2022/12/16/potion-craft-is-now-available-on-xbox/) | 공식 매체·검색 본문 | 재료 실험을 통한 지도 탐색과 효능 발견. |
| 7 | [Potion Craft Devlog 17](https://www.reddit.com/r/PotionCraft/comments/vtm8oe) | 개발자 게시물·검색 본문 | 위험 구역과 회복 구역 등 제조 탐색 난이도 설계. |
| 8 | [Potion Craft Devlog 18](https://www.reddit.com/r/PotionCraft/comments/w9geir/devlog_18_new_sorting_workinprogress_we_show_and/) | 개발자 게시물·검색 본문 | 원소 체계를 재료 정렬과 정보 표시로 연결. |
| 9 | [Little Alchemy 공식 힌트](https://littlealchemy.com/hints/) | 1차·검색 본문 | 4원소에서 발견을 확장하는 간단한 구조. 사물 수집 중심이라는 차이. |
| 10 | [Little Alchemy 2 공식 힌트](https://hints.littlealchemy2.com/) | 1차·검색 본문 | 생명·시간 같은 개념도 수집 대상으로 사용. |
| 11 | [Little Alchemy 2 에너지](https://hints.littlealchemy2.com/item/energy) | 1차·검색 본문 | 불+불 등 여러 에너지 제조법. 우리 게임의 같은 원소 처리와는 다름. |
| 12 | [Little Alchemy 2 생명](https://hints.littlealchemy2.com/item/life) | 1차·본문 확인 | 전기/시간/에너지와 원시 수프 등 여러 경로로 같은 개념 발견. |
| 13 | [Little Alchemy 2 힌트 UX](https://help.littlealchemy2.com/hints/using-hints) | 1차·검색 본문 | 만들 수 있는 대상만 알려주고 조합은 숨기는 힌트 방식. |
| 14 | [Alchemy 1000](https://alchemy1000.com/) | 공식 사이트·검색 본문 | 4원소에서 1000개 대상으로 확장. 범위가 넓은 사물 조합의 비교 사례. |
| 15 | [Doodle God 개발자 인터뷰](https://www.gamezebo.com/news/joybits-talks-the-evolution-of-doodle-god-and-the-road-to-doodle-god-2/) | 인터뷰·검색 본문 | 원소 조합 게임의 발전과 변형을 다룬 개발자 인터뷰. 상세 조합 근거로 사용하지 않음. |
| 16 | [Magicka 공식 매뉴얼](https://cdn.akamai.steamstatic.com/steam/apps/42910/manuals/Magicka%20manual%20body%20--%20English.pdf) | 1차·검색 본문 | 원소가 주문의 작용과 형태를 결정하는 설명. |
| 17 | [Magicka 2 공식 블로그 소개](https://blog.playstation.com/?p=155315) | 1차·본문 확인 | 물+불=증기, 물+냉기=얼음, 생명+방어=회복 지뢰. 물질·효과·전달 방식 혼합. |
| 18 | [Magicka 2 주문 소개](https://blog.playstation.com/?p=151226) | 1차·검색 본문 | 조합 및 반대 원소 상쇄 설명. 실패를 일관된 관계로 설명하는 참고. |
| 19 | [Guild Wars 2 Elementalist](https://www.guildwars2.com/en/the-game/professions/elementalist/) | 1차·검색 본문 | 4원소마다 주문 역할을 부여. 원소의 기능적 정체성 참고. |
| 20 | [Guild Wars 공식 매뉴얼](https://legal.guildwars.com/en/docs/gwf-manual.pdf) | 1차·검색 본문 | 흙의 힘·지구력, 공기의 속도·번개 등 원소가 담당하는 의미 범위. |
| 21 | [Magic: The Gathering — The Value of Pie](https://magic.wizards.com/en/news/making-magic/value-pie-2003-08-18-0) | 1차·본문 확인 | 계열이 할 수 있는 것과 할 수 없는 것을 정하는 설계. 조합표보다 역할 정의에 유용. |
| 22 | [Magic: The Gathering — Pie Fights](https://magic.wizards.com/en/news/making-magic/pie-fights-2016-11-14) | 1차·검색 본문 | 계열 간 철학적 충돌과 관계를 설계하는 참고. |
| 23 | [Atelier Sophie 2 조합 기본](https://www.koeitecmoamerica.com/manual/sophie2/en/5100.html) | 1차·검색 본문 | 같은 원소 성분을 연결하는 패널 조합. 원소 합성과 효과 강화의 차이 참고. |
| 24 | [Atelier Sophie 2 조합 흐름](https://www.koeitecmoamerica.com/manual/sophie2/en/5200.html) | 1차·검색 본문 | 레시피 기반 제조 흐름의 보조 자료. |
| 25 | [Atelier Ryza 조합 시스템](https://www.koeitecmoamerica.com/ryza/synthesis.html) | 1차·검색 본문 | 재료 배치로 셀을 열고 결과 효과와 레시피를 확장. |
| 26 | [Opus Magnum 공식 소개](https://www.zachtronics.com/opus-magnum/) | 1차·검색 본문 | 연금술 공정을 기계로 수행하고 효율을 개선. 향후 자동화 참고. |
| 27 | [Zachtronics 교육용 소개](https://zachtronics.com/zachademics/) | 1차·검색 본문 | 가상의 연금술 분자를 기계와 명령으로 조작하는 설명. |
| 28 | [Botania 공식 도감](https://botaniamod.net/lexicon.html) | 1차·검색 본문 | 자연 마법과 장비·자동화, 도감을 연결하는 참고. 웹판은 조합 이미지 미제공. |
| 29 | [Ars Magica 2 공식 언어 데이터](https://github.com/Mithion/ArsMagica2/blob/master/src/main/resources/assets/arsmagica2/lang/en_US.lang) | 1차·검색 본문 | 속성의 이름을 민첩함·가벼움 같은 실제 성질로 연결하는 참고. |
| 30 | [Noita 공식 소개](https://noitagame.com/) | 1차·검색 본문 | 물리적으로 시뮬레이션되는 세계. 물질 반응 중심 설계와 비교. |
| 31 | [Empedocles — Stanford Encyclopedia](https://plato.stanford.edu/entries/empedocles/) | 학술 해설·검색 본문 | 4가지 뿌리와 결합·분리의 능동 원리. 현대 게임의 6개 합성표를 제공하는 자료는 아님. |
| 32 | [Aristotle — Purdue 화학사](https://chemed.chem.purdue.edu/genchem/history/aristotle.html) | 대학 교육 자료·검색 본문 | 열/냉·습/건으로 원소 성질을 정의하는 참고. |
| 33 | [The four terrestrial elements — Oxford](https://www.cabinet.ox.ac.uk/node/3847) | 대학 소장 자료 해설·검색 본문 | 4원소와 대립 성질을 도식으로 표현. |
| 34 | [Aristotle Meteorology IV](https://classics.mit.edu/Aristotle/meteorology.4.iv.html) | 고전 번역·검색 본문 | 응고·용해 등을 열·냉·습·건과 연결한 역사적 설명. 현대 과학 규칙으로 취급하지 않음. |
| 35 | [연금술 필사본 — Manchester](https://www.digitalcollections.manchester.ac.uk/view/MS-GERMAN-00003) | 대학 소장 자료·검색 본문 | 소금·황·수은의 의인화와 상징 표현. 이름·도감 아트 참고. |

